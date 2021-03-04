using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gran : MonoBehaviour
{
    private GameObject grabobject;
    public Animator animator;
    public Rigidbody rb;
    public int isRightorLeft;
    public bool alreadyGrabbing = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(isRightorLeft))
        {
            if (isRightorLeft == 0)
            {
                animator.SetBool("left", true);
            }
            if (isRightorLeft == 1)
            {
                animator.SetBool("righ", true);
            }

            if (grabobject != null)
            {
                FixedJoint fj = grabobject.AddComponent<FixedJoint>();
                fj.connectedBody = rb;
                fj.breakForce = 9000;
            }
        }
        else if (Input.GetMouseButtonUp(isRightorLeft))
        {
            if (isRightorLeft == 0)
            {
                animator.SetBool("left", false);
            }
            if (isRightorLeft == 1)
            {
                animator.SetBool("righ", false);
            }

            if (grabobject != null)
            {
                Destroy(grabobject.GetComponent<FixedJoint>());
            }

            grabobject = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            grabobject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grabobject = null;
    }
}