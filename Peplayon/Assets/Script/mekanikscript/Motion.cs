using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class Motion : MonoBehaviour
    {
        #region Variable

        public static Rigidbody rb;

        public static Vector3 movement;
        private Animator anim;

        public float Speed;
        public float defaultsped;
        public float rotationSpeed;
        public float Jumping;
        public Transform leftfoot;
        public Transform midlle;
        public Transform rightfoot;
        public LayerMask ground;
        public GameObject cameraPlayer;
        public bool isClear = false;
        public bool animasi;

        public static float blend = 0.0f;
        public float acceleration;
        public bool isJumping;
        public bool defaultspeed = false;
        public bool isGround;
        private int blendtohas;

        #endregion Variable

        #region MonobehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            blendtohas = Animator.StringToHash("Blend");

            /* cameraParent = GameObject.FindGameObjectWithTag("PlayerCamera") as GameObject;*/
        }

        // Update is called once per frame
        private void Update()
        {
            if (defaultspeed)
            {
                Speed = defaultsped;
            }
            anim.SetFloat(blendtohas, blend);

            if (animasi && blend < 0.5f)
            {
                blend += Time.deltaTime * acceleration;
            }

            if (!animasi && blend >= 0f)
            {
                blend -= Time.deltaTime * acceleration;
            }

            if (isClear == true)
            {
                cameraPlayer.SetActive(true);
            }
            bool grab = Input.GetKeyDown(KeyCode.G);

            float movex = Input.GetAxisRaw("Horizontal");
            float movey = Input.GetAxisRaw("Vertical");
            bool jump = Input.GetKeyDown(KeyCode.Space);
            bool groundleft = Physics.Raycast(leftfoot.position, Vector3.down, 0.2f, ground);
            bool groundright = Physics.Raycast(rightfoot.position, Vector3.down, 0.1f, ground);
            bool groundmidlle = Physics.Raycast(midlle.position, Vector3.down, 0.1f, ground);

            if (groundleft || groundright || groundmidlle)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }

            if (grab == true)
            {
                anim.SetBool("Grab", true);
            }
            if (!grab)
            {
                anim.SetBool("Grab", false);
            }
            isJumping = jump && isGround;

            if (movex > 0.1f || movey > 0.1f || movex < -0.1f || movey < -0.1f)
            {
                animasi = true;
            }
            else
            {
                animasi = false;
            }
            if (isJumping)
            {
                anim.SetBool("Jump", true);
                rb.AddForce(Vector3.up * Jumping);
            }
            else
            {
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