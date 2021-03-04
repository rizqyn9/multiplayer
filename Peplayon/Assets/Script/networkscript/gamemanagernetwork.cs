using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class gamemanagernetwork : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PlayerPrefs.SetInt("choose1", 0);
        PlayerPrefs.SetInt("choose2", 0);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void choose1()
    {
        PlayerPrefs.SetInt("choose1", 1);
        PhotonNetwork.LoadLevel(2);
    }

    public void choose2()
    {
        PlayerPrefs.SetInt("choose2", 1);
        PhotonNetwork.LoadLevel(2);
    }
}