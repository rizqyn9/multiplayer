using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace wahyu
{
    public class CharacterSelect : MonoBehaviour
    {
        #region Variabel

        /* public ManagerMenu manager;*/
        public GameObject LoadingScene;
        public Slider slider;

        #endregion Variabel

        #region MonobehaviourCallBack

        public void Start()
        {
        }

        private void Update()
        {
        }

        #endregion MonobehaviourCallBack

        #region Private Method

        private IEnumerator LoadAsynchronously(int sceneIndex)
        {
            /*LoadingScene.SetActive(true);
            yield return new WaitForSeconds(1f);*/

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {
                /*float progress = Mathf.Clamp01(operation.progress / 2f);
                slider.value = progress;*/
                yield return null;
            }
        }

        private IEnumerator LoadAsynchronously1(int sceneIndex)
        {
            PlayerPrefs.DeleteAll();
            LoadingScene.SetActive(true);
            yield return new WaitForSeconds(1f);

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 2f);
                slider.value = progress;
                yield return new WaitForSeconds(4f);
                LoadingScene.SetActive(false);
            }
        }

        #endregion Private Method

        #region Public Method

        public void Character_one()
        {
            ManagerMenu manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerMenu>();
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CharacterOne", 1);
            manager.isSpawn = false;
            manager.SpawnCharacter(0);
            Debug.Log("1");
        }

        public void Character_two()
        {
            ManagerMenu manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerMenu>();
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CharacterTwo", 1);
            manager.isSpawn = false;
            manager.SpawnCharacter(1);
            Debug.Log("2");
        }

        public void Character_tree()
        {
            ManagerMenu manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerMenu>();
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CharacterTree", 1);
            manager.isSpawn = false;
            manager.SpawnCharacter(2);
            Debug.Log("3");
        }

        public void LoadLevelOne(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously1(sceneIndex));
        }

        public void LoadMainMenu(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        #endregion Public Method
    }
}