using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float ySensivity;
    public float xSensivity;
    public float maxAngle;
    private float yrotation = 0f;
    private float xrotation = 0f;
    public Transform PLAYERBODY;

    private Vector2 rotation = new Vector2(0, 0);
    private Quaternion camCenter;
    private Vector3 localpos;

    // Start is called before the first frame update
    private void Start()
    {
        camCenter = transform.localRotation;
        localpos = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        float xInput = Input.GetAxis("Mouse X") * xSensivity * Time.deltaTime;
        float yInput = Input.GetAxis("Mouse Y") * ySensivity * Time.deltaTime;

        xrotation -= yInput;
        xrotation = Mathf.Clamp(xrotation, -20f, 30f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);

        yrotation += xInput;
        yrotation = Mathf.Clamp(yrotation, -30f, 30f);

        PLAYERBODY.localRotation = Quaternion.Euler(0f, yrotation, 0f);

        /* setY();
         setX();*/
    }

    private void setY()
    {
        float yInput = Input.GetAxis("Mouse Y") * ySensivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(yInput, -Vector3.right);
        Quaternion t_delta = transform.localRotation * t_adj;

        if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
        {
            transform.localRotation = t_delta;
        }
    }

    private void setX()
    {
        float xInput = Input.GetAxis("Mouse X") * xSensivity * Time.deltaTime;
        Quaternion t_adjx = Quaternion.AngleAxis(xInput, Vector3.up);
        Quaternion t_deltax = transform.localRotation * t_adjx;
    }
}