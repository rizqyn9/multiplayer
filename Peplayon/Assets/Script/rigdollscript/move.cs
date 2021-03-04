using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine.UI;

namespace wahyu
{
    public class move : MonoBehaviourPunCallbacks

    {
        public float jumpForcs;
        public float strafeSpeed;
        public float Speed;
        public Animator animator;
        public Transform player;
        public Rigidbody rb;
        public GameObject cameraParent;

        public profilData ProfilData;
        public Text playerusername;

        public bool isground;
        public float rotationSpeed;
        public bool testing = false;

        // Start is called before the first frame update
        private void Start()
        {
            if (Camera.main.enabled == true)
            {
                Camera.main.enabled = false;
            }
            rb = GetComponent<Rigidbody>();

            cameraParent.SetActive(true);

            if (testing == true)
            {
                if (photonView.IsMine)
                {
                    photonView.RPC("Syncprofile", RpcTarget.All, ConnectServer.myProfile.username, ConnectServer.myProfile.level, ConnectServer.myProfile.exp);
                }
            }
        }

        [PunRPC]
        private void Syncprofile(string username, int lvl, int xp)
        {
            ProfilData = new profilData(username, lvl, xp);
            playerusername.text = ProfilData.username;
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            if (!photonView.IsMine) return;

            #region
            /*if (Input.GetKey(KeyCode.W))
          {
              if (Input.GetKey(KeyCode.LeftShift))
              {
                  rb.AddForce(rb.transform.forward * Speed * 1.5f);
              }

              animator.SetBool("walk", true);
              rb.AddForce(rb.transform.forward * Speed);
          }
          else
          {
              animator.SetBool("walk", false);
          }

          if (Input.GetKey(KeyCode.S))
          {
              rb.AddForce(-rb.transform.forward * Speed);
          }
          if (Input.GetKey(KeyCode.A))
          {
              rb.AddForce(-rb.transform.right * strafeSpeed);
          }
          if (Input.GetKey(KeyCode.D))
          {
              rb.AddForce(rb.transform.right * strafeSpeed);
          }*/

            #endregion

            if (Input.GetAxis("Jump") > 0)
            {
                if (isground)
                {
                    rb.AddForce(new Vector3(0, jumpForcs, 0));
                    isground = false;
                }
            }

            //rotate rb
            float movex = Input.GetAxis("Horizontal");
            float movey = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(movex, 0, movey);
            movement.Normalize();

            transform.Translate(movement * Speed * Time.deltaTime, Space.World);

            if (movement != Vector3.zero)
            {
                Quaternion quaternion = Quaternion.LookRotation(movement, Vector3.up);

                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, quaternion, rotationSpeed * Time.deltaTime);

                animator.SetBool("walk", true);
            }
            else
            {
                animator.SetBool("walk", false);
            }
        }
    }
}