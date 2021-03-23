using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wahyu
{
    public class UI : MonoBehaviour
    {
        #region Variable

        private static bool isPaused = false;
        private int index;

        private GameObject indicatoritempoint;
        private Transform jj;

        public GameObject UIeffect;
        public Text texteffect;
        public bool indicatoritemactive;
        public GameObject PauseMenu;
        public Canvas[] indicatoritem;
        public Transform uiindicator;
        public Transform tt;

        #endregion Variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    Paused();
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Resume();
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        private void LateUpdate()
        {
            if (indicatoritemactive)
            {
                Vector3 maxangle = new Vector3(0, 0, 0);
                Transform dd = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>().transform;
                jj.LookAt(jj.position + dd.forward);
                /*   if (jj.localEulerAngles.y > 90)
                   {
                       jj.localEulerAngles = maxangle;
                   }*/
            }
        }

        #endregion MonobehaviourCallBack

        #region PrivateMethod

        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }

        private void Paused()
        {
            isPaused = true;
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }

        #endregion PrivateMethod

        #region Public Method

        public void effectfaster()
        {
            texteffect.text = "FASTER";
        }

        public void effectslower()
        {
            texteffect.text = "SLOWER";
        }

        public void effectbigger()
        {
            texteffect.text = "BIGGER";
        }

        public void effecttransculent()
        {
            texteffect.text = "TRANSCULENT";
        }

        public void effecthighjump()
        {
            texteffect.text = "HIGH JUMP";
        }

        public void EFFECTSTUNT()
        {
            texteffect.text = "STUNT";
        }

        public void effectrespawn()
        {
            texteffect.text = "RESPAWN";
        }

        public void setIndicatorItem(int cc)
        {
            Transform bb = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>().transform;
            indicatoritempoint = GameObject.FindGameObjectWithTag("IndicatorPoint") as GameObject;
            jj = indicatoritempoint.transform;
            Instantiate(indicatoritem[cc], jj.position, Quaternion.identity, jj);
            indicatoritemactive = true;

            Debug.Log("j");
        }

        public void destroyIndicatorItem()
        {
            indicatoritemactive = false;
            GameObject currentCanvasIndicator = GameObject.FindGameObjectWithTag("IndicatorCanvas") as GameObject;

            Destroy(currentCanvasIndicator);
        }

        #endregion Public Method
    }
}