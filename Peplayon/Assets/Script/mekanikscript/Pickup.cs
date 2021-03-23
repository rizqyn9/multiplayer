using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Pickup : MonoBehaviour
    {
        #region Variable

        private Motion motion;
        private UI ui;
        private DetectChild detect;
        private Manager manager;
        private Transform player;
        private bool transculent = false;
        private bool triggerbox = false;
        private bool isused = true;

        /* [SerializeField]
         private int clint;*/

        [SerializeField]
        private GameObject fastereffect;

        [SerializeField]
        private GameObject respawneffect;

        [SerializeField]
        private GameObject biggereffect;

        [SerializeField]
        private GameObject slowerneffect;

        [SerializeField]
        private GameObject zonkneffect;

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

        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                triggerbox = true;
                motion = GameObject.FindGameObjectWithTag("Player").GetComponent<Motion>();
                ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
                detect = GameObject.FindGameObjectWithTag("IndicatorPoint").GetComponent<DetectChild>();
                manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
                player = GameObject.FindGameObjectWithTag("Player").transform;
                Debug.Log("hit");

                if (indexItem == 0)
                {
                    Jump();

                    ui.setIndicatorItem(0);

                    Debug.Log("jump");
                }
                else if (indexItem == 1)
                {
                    Bigger();

                    ui.setIndicatorItem(1);

                    Debug.Log("bigger");
                }
                else if (indexItem == 2)
                {
                    Translucent();

                    ui.setIndicatorItem(2);

                    Debug.Log("translucent");
                }
                else if (indexItem == 3)
                {
                    Slower();
                    ui.setIndicatorItem(3);

                    Debug.Log("sllower");
                }
                else if (indexItem == 4)
                {
                    ui.setIndicatorItem(4);

                    Respawwn(other);

                    Debug.Log("Respawn");
                }
                else if (indexItem == 5)
                {
                    ui.setIndicatorItem(4);

                    Stunt();

                    Debug.Log("stunt");
                }
                else if (indexItem == 6)
                {
                    Debug.Log("Zonk");
                    Destroy(gameObject);
                }
                else if (indexItem == 7)
                {
                    ui.setIndicatorItem(4);

                    Faster();

                    Debug.Log("faster");
                }

                mes.enabled = false;
                coll.enabled = false;
            }
        }

        #endregion MonobehaviourCallBack

        #region Public Method

        public void Respawwn(Collider tt)
        {
            StartCoroutine(setRespawn(tt));
        }

        public void Jump()
        {
            StartCoroutine(setJump());
        }

        public void Stunt()
        {
            StartCoroutine(setStunt());
        }

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
            transculent = true;
            StartCoroutine(setTranslucent());
        }

        public void Slower()
        {
            StartCoroutine(setSlower());
        }

        //respawn method
        public void destroy()
        {
            if (triggerbox == true && isused == false)
            {
                Destroy(gameObject);
                triggerbox = false;
                isused = true;
            }
        }

        public void stopallCoroutine()
        {
            StopAllCoroutines();
        }

        public void callbacktransculent()
        {
            Collider[] allobject = FindObjectsOfType<Collider>();
            foreach (Collider go in allobject)
            {
                if (go.CompareTag("Object"))
                {
                    go.isTrigger = false;
                }
            }
        }

        public void callbackfasterandslower()
        {
            motion.defaultsped = defaultSpeed;
        }

        public void callbacksjump()
        {
            motion.Jumping = 600f;
        }

        public void callbacksbigger()
        {
            Transform scale = GameObject.FindGameObjectWithTag("Player").transform;
            scale.transform.localScale = defaultScale;
        }

        #endregion Public Method

        #region Private Method

        private IEnumerator setStunt()
        {
            isused = false;
            ui.UIeffect.SetActive(true);
            ui.EFFECTSTUNT();
            GameObject effect = Instantiate(fastereffect, player.position, player.rotation, player) as GameObject;
            motion.defaultsped = 0f;
            motion.Speed = 0f;

            motion.Jumping = 0f;

            yield return new WaitForSeconds(5f);
            Destroy(effect);
            motion.defaultsped = defaultSpeed;
            motion.Speed = 10f;
            motion.Jumping = 600f;
            detect.ss();

            ui.UIeffect.SetActive(false);
            Destroy(gameObject);
        }

        private IEnumerator setJump()
        {
            isused = false;
            ui.UIeffect.SetActive(true);
            ui.effecthighjump();
            GameObject effect = Instantiate(fastereffect, player.position, player.rotation, player) as GameObject;
            motion.Jumping = 1000f;

            yield return new WaitForSeconds(5f);
            Destroy(effect);

            motion.Jumping = 600f;
            detect.ss();

            ui.UIeffect.SetActive(false);
            Destroy(gameObject);
        }

        private IEnumerator setFaster()
        {
            isused = false;
            ui.UIeffect.SetActive(true);
            ui.effectfaster();
            GameObject effect = Instantiate(fastereffect, player.position, player.rotation, player) as GameObject;
            motion.defaultsped = 20f;

            yield return new WaitForSeconds(5f);
            Destroy(effect);
            motion.defaultsped = defaultSpeed;
            detect.ss();

            ui.UIeffect.SetActive(false);
            Destroy(gameObject);
        }

        private IEnumerator setRespawn(Collider ttt)
        {
            isused = false;
            ui.UIeffect.SetActive(true);
            ui.effectrespawn();
            GameObject effect = Instantiate(respawneffect, player.position, player.rotation, player) as GameObject;
            yield return new WaitForSeconds(5f);
            Destroy(effect);
            motion.defaultsped = defaultSpeed;
            detect.ss();

            ui.UIeffect.SetActive(false);
            manager.SpawnCharacter();
            Destroy(gameObject);
            Destroy(ttt.gameObject);
        }

        private IEnumerator setSlower()
        {
            isused = false;
            ui.UIeffect.SetActive(true);
            ui.effectslower();
            GameObject effect = Instantiate(slowerneffect, player.position, player.rotation, player) as GameObject;
            motion.defaultsped = 2f;

            yield return new WaitForSeconds(5f);
            Destroy(effect);
            motion.defaultsped = defaultSpeed;
            detect.ss();

            ui.UIeffect.SetActive(false);
            Destroy(gameObject);
        }

        private IEnumerator setBigger()
        {
            isused = false;
            Transform scale = GameObject.FindGameObjectWithTag("Player").transform;
            ui.UIeffect.SetActive(true);
            ui.effectbigger();
            GameObject effect = Instantiate(biggereffect, scale.position, scale.rotation, scale) as GameObject;
            effect.transform.localScale = new Vector3(2, 2, 2);

            Vector3 bigger = new Vector3(1.5f, 1.5f, 1.5f);
            scale.transform.localScale += bigger;

            yield return new WaitForSeconds(10f);

            Destroy(effect);
            scale.transform.localScale = defaultScale;
            /*    scale.localPosition = Vector3.zero;*/
            ui.UIeffect.SetActive(false);
            detect.ss();

            Destroy(gameObject);
        }

        private IEnumerator setTranslucent()
        {
            isused = false;
            ui.UIeffect.SetActive(true);
            ui.effecttransculent();
            GameObject effect = Instantiate(biggereffect, player.position, player.rotation, player) as GameObject;

            Collider[] allobject = FindObjectsOfType<Collider>();
            foreach (Collider go in allobject)
            {
                if (go.CompareTag("Object"))
                {
                    go.isTrigger = true;
                }
            }

            yield return new WaitForSeconds(5f);

            foreach (Collider go in allobject)
            {
                if (go.CompareTag("Object"))
                {
                    go.isTrigger = false;
                }
            }

            detect.ss();

            ui.UIeffect.SetActive(false);
            Destroy(gameObject);
        }

        #endregion Private Method
    }
}