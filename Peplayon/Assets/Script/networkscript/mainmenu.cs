using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using wahyu;

public class mainmenu : MonoBehaviour
{
    public ConnectServer connectServer;

    public void JoinMatch()
    {
        connectServer.Join();
    }

    public void CreateMatch()
    {
        connectServer.Create();
    }

    public void ExitMatch()
    {
    }
}