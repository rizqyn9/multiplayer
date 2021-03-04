using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace wahyu
{
    public class Respawn : MonoBehaviour
    {
        public Camera camera;

        /*private static Respawn instance;
*/

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("respawn");
                Manager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
                manager.RespawnCharacter();
                Destroy(other.gameObject);
                camera.enabled = true;
            }
        }
    }
}