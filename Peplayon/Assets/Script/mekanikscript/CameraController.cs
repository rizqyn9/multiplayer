using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class CameraController : MonoBehaviour
    {
        #region Variable

        public Transform Player;
        public float SmoothSpeed;
        public Vector3 Offset;

        #endregion Variable

        #region MonobehavoiurCallBack

        private void Start()
        {
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Vector3 desiredPosition = Player.position + Offset;
            /*Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);*/
            transform.position = desiredPosition;

            transform.LookAt(Player);
        }

        #endregion MonobehavoiurCallBack
    }
}