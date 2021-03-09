using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Manager : MonoBehaviour
    {
        #region Variable

        public GameObject[] playerPrefab;
        public Transform[] SpawnPoint;
        public GameObject[] Item;
        public Transform[] SpawnItemPoint;
        public GameObject itemParent;
        public Vector3 lastCheckPoint;
        public Transform obstaclepoint;
        public Rigidbody obstacle;

        private int CharacterOneSelected;
        private int CharacterTwoSelected;
        private int CharacterTreeSelected;
        private int characterselect;
        private int TTF;
        private bool isspawn = false;
        private bool isitemspawn = false;

        #endregion Variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()

        {
            CharacterOneSelected = PlayerPrefs.GetInt("CharacterOne");
            CharacterTwoSelected = PlayerPrefs.GetInt("CharacterTwo");
            CharacterTreeSelected = PlayerPrefs.GetInt("CharacterTree");
        }

        // Update is called once per frame
        private void Update()
        {
            SpawnItem();

            if (CharacterOneSelected == 1 && isspawn == false)
            {
                isspawn = true;
                characterselect = 0;
                SpawnCharacter();
            }
            else if (CharacterTwoSelected == 1 && isspawn == false)
            {
                isspawn = true;
                characterselect = 1;
                SpawnCharacter();
            }
            else if (CharacterTreeSelected == 1 && isspawn == false)
            {
                isspawn = true;
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
            Transform spawn = SpawnPoint[Random.Range(0, SpawnPoint.Length)];
            Instantiate(playerPrefab[characterselect], spawn.position, spawn.rotation);
        }

        public void RespawnCharacter()
        {
            Respawn respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();

            Instantiate(playerPrefab[characterselect], lastCheckPoint, Quaternion.identity);
        }

        public void SpawnItem()
        {
            if (isitemspawn == false)
            {
                for (int a = 0; a <= 2; a++)
                {
                    isitemspawn = true;
                    int itemSpawn = Random.Range(0, Item.Length);
                    Instantiate(Item[itemSpawn], SpawnItemPoint[a].position, SpawnItemPoint[a].rotation);
                }
                return;
            }
        }

        public void SpawnObstacle()
        {
            Rigidbody ob = Instantiate(obstacle, obstaclepoint.position, obstaclepoint.rotation);

            ob.AddForce(Vector3.right * 20f, ForceMode.VelocityChange);
        }

        #endregion Public Method
    }
}