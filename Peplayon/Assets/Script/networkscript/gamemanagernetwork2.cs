using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using wahyu;

public class gamemanagernetwork2 : MonoBehaviourPunCallbacks
{
    private int chose1;
    private int chose2;
    private Text username;

    public string[] prefab;
    public Transform[] Spawn;

    // Start is called before the first frame update
    private void Start()
    {
        if (photonView.IsMine)
        {
            chose1 = PlayerPrefs.GetInt("choose1");
            chose2 = PlayerPrefs.GetInt("choose2");

            username = GameObject.Find("HUD/username/text").GetComponent<Text>();
            username.text = ConnectServer.myProfile.username;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (chose1 == 1)
        {
            chose1 = 2;
            spawn(0);

            return;
        }
        else if (chose2 == 1)
        {
            chose2 = 2;
            spawn(1);
            return;
        }
    }

    private void spawn(int choose)
    {
        Transform random = Spawn[Random.Range(0, Spawn.Length)];
        PhotonNetwork.Instantiate(prefab[choose], random.position, random.rotation);
    }
}