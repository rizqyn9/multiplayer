using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Obstecle1 : MonoBehaviour
    {
        public Vector3 positionToMoveTo;
        public float dur;
        private Vector3 originPos;
        private bool ulang = true;

        private void Start()
        {
            originPos = transform.localPosition;
        }

        private void Update()
        {
            if (ulang)
            {
                StartCoroutine(LerpPosition(positionToMoveTo, dur));
                ulang = false;
            }

            if (Input.GetKey(KeyCode.N))
            {
            }
        }

        private IEnumerator LerpPosition(Vector3 targetPosition, float duration)
        {
            float time = 0;
            Vector3 startPosition = transform.position;

            while (time < duration)
            {
                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = targetPosition;
            yield return new WaitForSeconds(dur);
            StartCoroutine(minLerpPosition(positionToMoveTo, dur));
        }

        private IEnumerator minLerpPosition(Vector3 targetPosition, float duration)
        {
            float time = 0;

            while (time < duration)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, originPos, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = originPos;
            yield return new WaitForSeconds(dur);
            ulang = true;
        }
    }
}