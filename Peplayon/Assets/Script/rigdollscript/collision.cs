using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class collision : MonoBehaviour
    {
        // Start is called before the first frame update
        public move mov;

        private void Start()
        {
            mov = GameObject.FindObjectOfType<move>().GetComponent<move>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            mov.isground = true;
        }
    }
}