using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ItemPickup : NetworkBehaviour
{
    private CharacterControls characterControls;
    public int indexItem;
    public float jumpHeightplus;
    public float speedplus;
    public float speedandjumpStun;
    public float speedmin;
    public float Countdown;
    public MeshRenderer mes;
    public Collider coll;
    private GameObject ssignAuthorityObj;
    private bool iya = false;
    private GameObject ohteer;

    private UI ui;
    private DetectChild detect;

    private void Update()
    {
        if (iya)
        {
            if (hasAuthority)
            {
                iya = false;
                ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
                detect = GameObject.FindGameObjectWithTag("IndicatorItemSpawn").GetComponent<DetectChild>();
                Debug.Log("PICKUP");
                if (indexItem == 1)
                {
                    ui.setCommandInd(0);
                    Debug.Log("JUMP");
                    Jump();
                    ff();
                }
                else if (indexItem == 2)
                {
                    Debug.Log("RUN");
                    Run();
                    setTransparentBox();
                }
                else if (indexItem == 3)
                {
                    Debug.Log("SLOW");
                    Slow();
                    setTransparentBox();
                }
                else if (indexItem == 4)
                {
                    Debug.Log("TRANSCULENT");
                    Transculent();
                    setTransparentBox();
                }
                else if (indexItem == 5)
                {
                    Debug.Log("FLASHBACK");
                    Flashback(ohteer.gameObject);
                    setTransparentBox();
                }
                else if (indexItem == 6)
                {
                    Debug.Log("STUNT");
                    Stunt();
                    setTransparentBox();
                }

                mes.enabled = false;
                coll.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        characterControls = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControls>();

        if (other.CompareTag("Player"))
        {
            iya = true;
            ohteer = other.gameObject;
            NetworkIdentity playerr = other.GetComponent<NetworkIdentity>();
            NetworkIdentity itemm = GetComponent<NetworkIdentity>();
            ClientInstance cl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
            cl.hasautorry(itemm, playerr);
        }
    }

    [Command]
    private void ff()
    {
        setTransparentBox();
    }

    [ClientRpc]
    public void setTransparentBox()
    {
        Debug.Log("SENT ALL TO RPC");
        mes.enabled = false;
        coll.enabled = false;
    }

    public void Jump()
    {
        StartCoroutine(setJump());
    }

    public void Run()
    {
        StartCoroutine(setRun());
    }

    public void Slow()
    {
        StartCoroutine(setSlow());
    }

    public void Transculent()
    {
        StartCoroutine(setTransculent());
    }

    public void Flashback(GameObject Player)
    {
        StartCoroutine(setFlashback(Player));
    }

    public void Stunt()
    {
        StartCoroutine(setStun());
    }

    private IEnumerator setJump()
    {
        characterControls.jumpHeight = jumpHeightplus;

        yield return new WaitForSeconds(Countdown);

        characterControls.jumpHeight = 5f;
        detect.Child();
    }

    private IEnumerator setRun()
    {
        characterControls.speed = speedplus;

        yield return new WaitForSeconds(Countdown);

        characterControls.speed = 10f;
    }

    private IEnumerator setSlow()
    {
        characterControls.speed = speedmin;

        yield return new WaitForSeconds(Countdown);

        characterControls.speed = 10f;
    }

    private IEnumerator setTransculent()
    {
        Collider[] AllObject = FindObjectsOfType<Collider>();

        foreach (Collider co in AllObject)
        {
            if (co.CompareTag("Object"))
            {
                co.isTrigger = true;
            }
        }

        yield return new WaitForSeconds(Countdown);

        foreach (Collider co in AllObject)
        {
            if (co.CompareTag("Object"))
            {
                co.isTrigger = false;
            }
        }
    }

    private IEnumerator setFlashback(GameObject player)
    {
        ClientInstance clientInstance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();

        yield return new WaitForSeconds(Countdown);

        player.transform.position = clientInstance.currenctCheckPoint;
    }

    private IEnumerator setStun()
    {
        characterControls.speed = speedandjumpStun;
        characterControls.jumpHeight = speedandjumpStun;

        yield return new WaitForSeconds(Countdown);
        characterControls.jumpHeight = 5f;
        characterControls.speed = 10f;
    }
}