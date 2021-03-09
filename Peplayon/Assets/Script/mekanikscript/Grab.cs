using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Grab : MonoBehaviour
    {
        public GameObject objectgrab;
        /*private Collider collider;*/
        public Rigidbody rb;

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            /*collider = GetComponent<Collider>();*/
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                /*ollider.enabled = true;*/

                Debug.Log("grab");
                if (objectgrab != null)
                {
                    FixedJoint fj = objectgrab.AddComponent<FixedJoint>();

                    fj.connectedBody = rb;
                    fj.breakForce = 100;
                    Debug.Log("grab active");
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                /*                collider.enabled = false;*/

                Debug.Log("grabinactive");
                if (objectgrab != null)
                {
                    Destroy(objectgrab.GetComponent<FixedJoint>());
                }

                objectgrab = null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("item"))
            {
                objectgrab = other.gameObject;
                Debug.Log("grab object");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            objectgrab = null;
        }
    }
}