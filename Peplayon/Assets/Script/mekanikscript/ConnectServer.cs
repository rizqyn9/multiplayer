using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

namespace wahyu
{
    [System.Serializable]
    public class profilData
    {
        public string username;
        public int level;
        public int exp;

        public profilData()
        {
            this.username = "default username";
            this.level = 0;
            this.exp = 0;
        }

        public profilData(string u, int l, int x)
        {
            this.username = u;
            this.level = l;
            this.exp = x;
        }
    }

    public class ConnectServer : MonoBehaviourPunCallbacks
    {
        public InputField usernameField;
        public static profilData myProfile = new profilData();

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            myProfile = Data.LoadProfile();
            usernameField.text = myProfile.username;
            Connect();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        public void Connect()
        {
            PhotonNetwork.GameVersion = ("0.0.1");
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connect");
            /* Join();*/
            base.OnConnectedToMaster();
        }

        public void nextScene()
        {
            PhotonNetwork.LoadLevel(1);
        }

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
            if (string.IsNullOrEmpty(usernameField.text))
            {
                myProfile.username = "Random User" + Random.Range(0, 100000);
            }
            else
            {
                myProfile.username = usernameField.text;
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Data.SaveProfile(myProfile);
                Debug.Log("Start Game");

                PhotonNetwork.LoadLevel(1);
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
    }
}