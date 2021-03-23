using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Pickup pk = GameObject.FindGameObjectWithTag("item").GetComponent<Pickup>();
                UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
                Manager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
                Debug.Log("respawn");

                ui.UIeffect.SetActive(false);
                pk.callbacktransculent();

                pk.stopallCoroutine();
                ui.destroyIndicatorItem();
                pk.destroy();

                Destroy(other.gameObject);

                manager.RespawnCharacter();

                camera.enabled = true;
            }
        }
    }
}