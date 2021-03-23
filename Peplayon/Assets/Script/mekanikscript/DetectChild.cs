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
                if (transform)
                {
                    UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
                    ui.indicatoritemactive = false;
                    Canvas.Destroy(child.gameObject);
                }
            }
        }
    }
}