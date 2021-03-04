using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform Player;
    public float SmoothSpeed;
    public Vector3 Offset;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 desiredPosition = Player.position + Offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(Player);
    }
}