using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class UI : MonoBehaviour
    {
        #region Variable

        private static bool isPaused = false;
        private int index;
        private Canvas currentCanvasIndicator;
        private GameObject indicatoritempoint;

        public GameObject PauseMenu;
        public Canvas[] indicatoritem;

        #endregion Variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    Paused();
                }
                else
                {
                    Resume();
                }
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

        public void setIndicatorItem(int cc)
        {
            indicatoritempoint = GameObject.FindGameObjectWithTag("IndicatorPoint") as GameObject;
            Transform jj = indicatoritempoint.transform;

            Instantiate(indicatoritem[cc], jj.position, Quaternion.identity, jj);
            Debug.Log("j");
        }

        private void destroyIndicatorItem()
        {
            currentCanvasIndicator = GameObject.FindGameObjectWithTag("IndicatorCanvas").GetComponent<Canvas>();

            Destroy(currentCanvasIndicator);
        }

        #endregion Public Method
    }
}