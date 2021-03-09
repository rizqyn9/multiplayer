using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    #region Variable

    public Canvas eliminasi;
    public Text one;
    public Text two;
    public Text tree;
    public string[] qualifiqied;
    public int nextSceneIndex;

    private int b = 0;
    private bool iswin = false;
    private bool nextscene = false;

    #endregion Variable

    #region MonoBehaviourCallBack

    // Update is called once per frame
    private void Update()
    {
        if (nextscene)
        {
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }
    }

    #endregion MonoBehaviourCallBack

    #region Private Method

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Eliminasi();
            setUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void Eliminasi()
    {
        if (b == 0 && iswin == false)
        {
            iswin = true;

            b++;
            nextscene = true;
            return;
        }
        else if (b == 1 && iswin == false)
        {
            iswin = true;
            b++;
            one.text = "2";
            return;
        }
        else if (b == 2 && iswin == false)
        {
            iswin = true;
            b++;
            one.text = "3";

            return;
        }
    }

    private void setUI()
    {
        eliminasi.enabled = true;
        /* if (b == 0)
         {
             Debug.Log("1");
             one.text = "1";
         }
         else if (b == 1)
         {
             Debug.Log("2");
             one.text = "2";
         }
         else
         {
             Debug.Log("3");
             one.text = "3";
         }*/
    }

    #endregion Private Method
}