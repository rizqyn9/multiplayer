using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Canvas eliminasi;
    public Text one;
    public Text two;
    public Text tree;
    public string[] qualifiqied;
    private int b = 0;
    private bool iswin = false;

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (b == 0 && iswin == false)
            {
                iswin = true;
                eliminasi.enabled = true;
                b++;
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

        if (b == 0)
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        iswin = false;
    }
}