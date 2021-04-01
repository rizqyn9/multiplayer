using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : NetworkBehaviour
{
    public GameObject[] IndicatorItem;
    private Transform IndicatorPointParent;
    private bool Call;
    private GameObject tt;

    private void LateUpdate()
    {
        if (Call)
        {
            /*  Transform Camera = GameObject.FindGameObjectWithTag("Tes").transform;
              IndicatorPointParent.LookAt(IndicatorPointParent.position, Camera.forward);*/
        }
    }

    public void setCommandInd(int b)
    {
        if (!hasAuthority) return;
        setIndItem(b);
        Debug.Log("indicatoritem");
    }

    public void setCommanddes(Transform v)
    {
        if (!hasAuthority) return;
        setDestroyIndItem(v);
        Debug.Log("indicatoritem");
    }

    [Command]
    public void setIndItem(int a)
    {
        SetIndicatorItem(a);
        SetIndicatorItemmm(a);
    }

    [Command]
    public void setDestroyIndItem(Transform z)
    {
        destroy(z);
    }

    [ClientRpc]
    public void SetIndicatorItem(int index)
    {
        if (!isLocalPlayer) return;
        Transform IndicatorItemPoint = GameObject.FindGameObjectWithTag("IndicatorItemSpawn").transform;
        IndicatorPointParent = IndicatorItemPoint.transform;
        tt = Instantiate(IndicatorItem[index], IndicatorPointParent.position, Quaternion.identity, IndicatorPointParent);

        Call = true;
    }

    [ClientRpc]
    public void SetIndicatorItemmm(int index)
    {
        if (isLocalPlayer) return;
        Transform IndicatorItemPoint = GameObject.FindGameObjectWithTag("MultiplayerItemSpawn").transform;
        IndicatorPointParent = IndicatorItemPoint.transform;
        tt = Instantiate(IndicatorItem[index], IndicatorPointParent.position, Quaternion.identity, IndicatorPointParent);

        Call = true;
    }

    [ClientRpc]
    public void destroy(Transform dd)
    {
        Destroy(tt);
    }
}