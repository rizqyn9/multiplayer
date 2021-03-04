using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Matchmaking : MonoBehaviourPunCallbacks
{
    public Camera camera;

    #region gajadi

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    private void start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect");

        base.OnConnectedToMaster();
    }

    #endregion gajadi

    public void Join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined a room");
        StartGame();
        base.OnJoinedRoom();
    }

    public void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("Start Game");

            PhotonNetwork.LoadLevel(2);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Create();
        base.OnJoinRandomFailed(returnCode, message);
    }

    public void Create()
    {
        Debug.Log("Created a room");

        PhotonNetwork.CreateRoom("");
    }

    public void LeavRoom()
    {
        camera.enabled = true;
        Debug.Log("Dissconnect");
        PhotonNetwork.Disconnect();
    }
}