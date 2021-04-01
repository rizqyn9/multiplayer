using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : NetworkBehaviour
{
    private GameObject player;

    [Client]
    private void OnTriggerEnter(Collider other)
    {
        if (!hasAuthority) return;
        if (other.CompareTag("Player"))
        {
            ClientInstance client = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
            other.transform.position = client.currenctCheckPoint;
        }
    }

    /*[Command]
    public void NetworkRespawnPlayer()
    {
        ClientInstance manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
        manager.NetworkreSpawnPlayer();
    }*/
}