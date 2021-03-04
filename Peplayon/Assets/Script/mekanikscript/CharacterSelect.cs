using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace wahyu
{
    public class CharacterSelect : MonoBehaviour
    {
        #region variable

        public Slider slider;
        public GameObject LoadingScene;

        #endregion variable

        #region MonobehaviourCallBack

        private void Start()
        {
        }

        private void Update()
        {
        }

        #endregion MonobehaviourCallBack

        #region Private Method

        private IEnumerator LoadAsynchronously(int sceneIndex)
        {
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
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CharacterOne", 1);
            LoadLevelOne(0);
            PlayerPrefs.SetInt("ccc", 1);
        }

        public void Character_two()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CharacterTwo", 1);
            LoadLevelOne(0);
            PlayerPrefs.SetInt("ccc", 1);
        }

        public void Character_tree()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CharacterTree", 1);
            LoadLevelOne(0);
            PlayerPrefs.SetInt("ccc", 1);
        }

        public void LoadLevelOne(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        public void LoadMainMenu(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously1(sceneIndex));
        }

        #endregion Public Method
    }
}