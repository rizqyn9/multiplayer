using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class ManagerMainMenu : MonoBehaviour
    {
        #region variable

        public GameObject[] PlayerPrefab;
        public Transform SpawnPoint;
        public float Speed;
        private GameObject CurrentCharacter;
        private int CharacterOnSelect1;
        private int CharacterOnSelect2;
        private int CharacterOnSelect3;

        public bool isSpawn = false;
        private int selectRotate;

        #endregion variable

        #region MonobehaviourCallBack

        private void Start()
        {
            isSpawn = false;
            CharacterOnSelect1 = PlayerPrefs.GetInt("CharacterOne");
            CharacterOnSelect2 = PlayerPrefs.GetInt("CharacterTwo");
            CharacterOnSelect3 = PlayerPrefs.GetInt("CharacterTree");
        }

        private void Update()
        {
            if (CharacterOnSelect1 == 1)
            {
                SpawnCharacterMainMenu(0);
                selectRotate = 0;
            }
            else if (CharacterOnSelect2 == 1)
            {
                SpawnCharacterMainMenu(1);
                selectRotate = 1;
            }
            else if (CharacterOnSelect3 == 1)
            {
                SpawnCharacterMainMenu(2);
                selectRotate = 2;
            }
            else
            {
                SpawnCharacterMainMenu(0);
                selectRotate = 0;
            }

            /*  Transform getplayer = GameObject.FindGameObjectWithTag("Player").transform;
              getplayer.transform.Rotate(0, Time.deltaTime * Speed, 0);*/
        }

        #endregion MonobehaviourCallBack

        #region Private Method

        private void SpawnCharacterMainMenu(int select)
        {
            if (!isSpawn)
            {
                if (!CurrentCharacter)
                {
                    Destroy(CurrentCharacter);
                }

                isSpawn = true;

                GameObject spawn = Instantiate(PlayerPrefab[select], SpawnPoint.position, SpawnPoint.rotation);
                CurrentCharacter = spawn;
            }
        }

        #endregion Private Method
    }
}