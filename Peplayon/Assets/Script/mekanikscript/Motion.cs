﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Motion : MonoBehaviour
    {
        #region Variable

        private Rigidbody rb;
        /* private float sprintmodifier = 1.5f;
 */
        private Vector3 movement;

        public float Speed;
        public float rotationSpeed;
        public float Jumping;
        public Transform grounded;
        public LayerMask ground;
        public GameObject cameraPlayer;

        public bool isClear = false;

        #endregion Variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            /* cameraParent = GameObject.FindGameObjectWithTag("PlayerCamera") as GameObject;*/
        }

        // Update is called once per frame
        private void Update()
        {
            if (isClear == true)
            {
                cameraPlayer.SetActive(true);
            }
            float movex = Input.GetAxisRaw("Horizontal");
            float movey = Input.GetAxisRaw("Vertical");
            bool jump = Input.GetKeyDown(KeyCode.Space);
            bool isGround = Physics.Raycast(grounded.position, Vector3.down, 0.1f, ground);

            bool isJumping = jump && isGround;

            if (isJumping)
            {
                rb.AddForce(Vector3.up * Jumping);
            }
            movement = new Vector3(movex, 0, movey);
            movement.Normalize();
        }

        private void FixedUpdate()
        {
            float AdjustSpeed = Speed;

            transform.Translate(movement * AdjustSpeed * Time.deltaTime, Space.World);

            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }

        #endregion MonobehaviourCallBack
    }
}