using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace wahyu
{
    public class Manager : MonoBehaviourPunCallbacks
    {
        #region Variable

        public string[] playerPrefab;
        public Transform[] SpawnPoint;
        public string[] Item;
        public Transform[] SpawnItemPoint;
        public GameObject itemParent;
        public Vector3 lastCheckPoint;

        private int CharacterOneSelected;
        private int CharacterTwoSelected;
        private int CharacterTreeSelected;
        private int characterselect;
        private int TTF;

        #endregion Variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()

        {
            if (!photonView.IsMine) return;
            CharacterOneSelected = PlayerPrefs.GetInt("CharacterOne");
            CharacterTwoSelected = PlayerPrefs.GetInt("CharacterTwo");
            CharacterTreeSelected = PlayerPrefs.GetInt("CharacterTree");
        }

        // Update is called once per frame
        private void Update()
        {
            if (!photonView.IsMine) return;
            if (CharacterOneSelected == 1)
            {
                SpawnItem();
                CharacterOneSelected = 10;
                characterselect = 0;
                SpawnCharacter();
            }
            else if (CharacterTwoSelected == 1)
            {
                SpawnItem();
                CharacterTwoSelected = 10;
                characterselect = 1;
                SpawnCharacter();
            }
            else if (CharacterTreeSelected == 1)
            {
                SpawnItem();
                CharacterTreeSelected = 10;
                characterselect = 2;
                SpawnCharacter();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        #endregion MonobehaviourCallBack

        #region Public Method

        public void SpawnCharacter()
        {
            if (!photonView.IsMine) return;
            Transform spawn = SpawnPoint[Random.Range(0, SpawnPoint.Length)];
            PhotonNetwork.Instantiate(playerPrefab[characterselect], spawn.position, spawn.rotation);
        }

        public void RespawnCharacter()
        {
            Respawn respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();
            if (!photonView.IsMine) return;

            PhotonNetwork.Instantiate(playerPrefab[characterselect], lastCheckPoint, Quaternion.identity);
        }

        public void SpawnItem()
        {
            for (int a = 0; a <= 2; a++)
            {
                int itemSpawn = Random.Range(0, Item.Length);
                PhotonNetwork.Instantiate(Item[itemSpawn], SpawnItemPoint[a].position, SpawnItemPoint[a].rotation);
            }
        }

        #endregion Public Method
    }
}