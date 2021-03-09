using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wahyu;

public class Matchmaking : MonoBehaviour
{
    #region Variable

    public Camera camera;
    public int nextSceneIndex;

    private LoadLevel loadLevel;

    #endregion Variable

    #region gajadi

    private void start()
    {
    }

    public void Connect()
    {
    }

    #endregion gajadi

    #region Public Method

    public void StartGame()
    {
        Debug.Log("Start Game");
        /* loadLevel.LoadMainMenu(2);*/
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    }

    public void LeaveRoom()
    {
        camera.enabled = true;
        Debug.Log("Dissconnect");
    }

    #endregion Public Method
}