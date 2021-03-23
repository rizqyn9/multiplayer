using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wahyu
{
    public class CutScene : MonoBehaviour
    {
        #region Variable

        public GameObject Camera1;
        private GameObject one;
        private Camera onee;
        private bool cut = true;
        private bool clear = false;
        private bool freez = false;

        public Canvas CountStart;
        public Text first;
        public Text two;
        public Text tree;

        #endregion Variable

        #region MonoBehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
            if (clear)
            {
                Motion motion = GameObject.FindGameObjectWithTag("Player").GetComponent<Motion>();
                motion.isClear = true;
            }

            one = Camera.main.gameObject;
            onee = Camera.main;
        }

        // Update is called once per frame
        private void Update()
        {
            if (clear)
            {
                Motion motion = GameObject.FindGameObjectWithTag("Player").GetComponent<Motion>();

                motion.isClear = true;

                if (!freez)
                {
                    motion.defaultspeed = true;
                }
            }
            if (cut)
            {
                /* Motion motion = GameObject.FindGameObjectWithTag("Player").GetComponent<Motion>();

                 motion.Speed = 0f;*/
                StartCoroutine(cutscenestartgame());
                cut = false;
            }
        }

        #endregion MonoBehaviourCallBack

        #region Private Method

        private IEnumerator cutscenestartgame()
        {
            freez = true;
            LeanTween.move(one, new Vector3(0, 19.8999996f, 253.399994f), 9f);
            yield return new WaitForSeconds(10);
            onee.enabled = false;
            Camera1.SetActive(true);
            LeanTween.move(Camera1, new Vector3(2.5f, 18, -53.5999985f), 3f);
            yield return new WaitForSeconds(2);

            LeanTween.move(Camera1, new Vector3(14.3999996f, 23.8999996f, -94.5f), 1f);

            LeanTween.rotate(Camera1, new Vector3(48.2000122f, 180f, 0), 1f);
            yield return new WaitForSeconds(1);
            LeanTween.move(Camera1, new Vector3(-11.6999998f, 23.8999996f, -94.5f), 4f);
            yield return new WaitForSeconds(3);
            clear = true;
            yield return new WaitForSeconds(1);
            Camera1.SetActive(false);
            CountStart.enabled = true;
            yield return new WaitForSeconds(1);
            first.enabled = false;
            two.enabled = true;
            yield return new WaitForSeconds(1);
            two.enabled = false;
            tree.enabled = true;
            yield return new WaitForSeconds(1);
            CountStart.enabled = false;
            freez = false;
        }
    }

    #endregion Private Method
}