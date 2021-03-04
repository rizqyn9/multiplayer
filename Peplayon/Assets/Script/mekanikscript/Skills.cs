using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Skills : MonoBehaviour
    {
        #region variable

        private Transform player;
        private Vector3 scaleOrigin;
        private float cooldown;

        public int skillPlayer;
        public Motion motion;

        #endregion variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
            scaleOrigin = transform.localScale;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) Skill(skillPlayer);
            if (cooldown > 0) cooldown -= Time.deltaTime;
        }

        #endregion MonobehaviourCallBack

        #region Private Method

        private void Skill(int list)
        {
            if (list == 1 && cooldown <= 0)
            {
                StartCoroutine(bigger());
            }

            if (list == 2 && cooldown <= 0)
            {
                StartCoroutine(IncreaseSpeed());
            }
        }

        private IEnumerator bigger()
        {
            cooldown += 3;
            Vector3 Big = new Vector3(5f, 5f, 5f);

            transform.localScale += Vector3.Lerp(transform.localScale, Big, Time.deltaTime * 2f);
            yield return new WaitForSeconds(1);
            transform.localScale = scaleOrigin;
        }

        private IEnumerator IncreaseSpeed()
        {
            cooldown += 3;
            motion.Speed = 10;
            yield return new WaitForSeconds(4);
            motion.Speed = 5;
        }

        #endregion Private Method
    }
}