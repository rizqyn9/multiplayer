using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class DetectChild : MonoBehaviour
    {
        public void ss()
        {
            foreach (Transform child in transform)
            {
                Canvas.Destroy(child.gameObject);
            }
        }
    }
}