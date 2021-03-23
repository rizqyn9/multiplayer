using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class CameraController : MonoBehaviour
    {
        #region Variable

        public Transform Player;
        public Transform camera;
        public float SmoothSpeed;
        public float speed;
        public Vector3 Offset;

        public float ySensivity;
        public float xSensivity;
        public float maxAngle;

        private Vector2 rotation = new Vector2(0, 0);
        private Quaternion camCenter;
        private Vector3 localpos;

        #endregion Variable

        #region MonobehavoiurCallBack

        private void Start()
        {
            camCenter = camera.localRotation;
            localpos = transform.localPosition;
        }

        private void Update()
        {
            /*  setY()*/
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            Vector3 desiredPosition = Player.position + Offset;
            /*  Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);*/
            transform.position = desiredPosition;
            transform.LookAt(Player);
            ;
        }

        #endregion MonobehavoiurCallBack

        #region Private Method

        private void setY()
        {
            /*float yInput = Input.GetAxis("Mouse Y") * ySensivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(yInput, -Vector3.right);
            Quaternion t_delta = camera.localRotation * t_adj;

            if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
            {
                A = t_delta;
            }*/
        }

        #endregion Private Method
    }
}