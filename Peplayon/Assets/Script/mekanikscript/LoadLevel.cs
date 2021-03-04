using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class LoadLevel : MonoBehaviour
{
    #region variable

    public Slider slider;
    public GameObject LoadingScene;

    #endregion variable

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

    public void LoadLevell(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void LoadMainMenu(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously1(sceneIndex));
    }

    #endregion Public Method
}