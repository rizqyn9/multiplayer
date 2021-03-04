using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wahyu;

public class respawnPoint : MonoBehaviour
{
    private Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.lastCheckPoint = transform.position;
        }
    }
}