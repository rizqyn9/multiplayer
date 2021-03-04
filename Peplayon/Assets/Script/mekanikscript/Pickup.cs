using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace wahyu
{
    public class Pickup : MonoBehaviour
    {
        #region Variable

        private Motion motion;
        private UI ui;
        private DetectChild detect;

        public int indexItem;
        public float defaultSpeed;
        public MeshRenderer mes;
        public Collider coll;
        public int IndicatorItem;
        public Vector3 defaultScale;

        #endregion Variable

        #region MonobehaviourCallBack

        private void Start()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                motion = GameObject.FindGameObjectWithTag("Player").GetComponent<Motion>();
                ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
                detect = GameObject.FindGameObjectWithTag("IndicatorPoint").GetComponent<DetectChild>();
                Debug.Log("hit");

                if (indexItem == 1)
                {
                    Faster();
                    ui.setIndicatorItem(0);

                    Debug.Log("faster");
                }
                else if (indexItem == 2)
                {
                    Bigger();
                    ui.setIndicatorItem(1);

                    Debug.Log("bigger");
                }
                else if (indexItem == 3)
                {
                    Translucent();
                    ui.setIndicatorItem(2);

                    Debug.Log("translucent");
                }

                mes.enabled = false;
                coll.enabled = false;
            }
        }

        #endregion MonobehaviourCallBack

        #region Public Method

        public void Faster()
        {
            StartCoroutine(setFaster());
        }

        public void Bigger()
        {
            StartCoroutine(setBigger());
        }

        public void Translucent()
        {
            StartCoroutine(setTranslucent());
        }

        #endregion Public Method

        #region Private Method

        private IEnumerator setFaster()
        {
            motion.Speed = 20f;

            yield return new WaitForSeconds(5f);

            motion.Speed = defaultSpeed;
            detect.ss();
            Destroy(gameObject);
        }

        private IEnumerator setBigger()
        {
            Transform scale = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 currentPosition = scale.localPosition;
            Vector3 bigger = new Vector3(3, 3, 3);
            scale.transform.localScale += bigger;

            yield return new WaitForSeconds(5f);

            scale.transform.localScale = defaultScale;
            scale.localPosition = Vector3.zero;

            detect.ss();
            Destroy(gameObject);
        }

        private IEnumerator setTranslucent()
        {
            Collider player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
            Rigidbody rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

            rb.isKinematic = true;
            player.isTrigger = true;

            yield return new WaitForSeconds(5f);

            rb.isKinematic = false;
            player.isTrigger = false;
            motion.Speed = defaultSpeed;
            detect.ss();
            Destroy(gameObject);
        }

        #endregion Private Method
    }
}