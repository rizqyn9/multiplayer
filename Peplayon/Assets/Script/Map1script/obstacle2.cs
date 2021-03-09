using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle2 : MonoBehaviour
{
    public float Speed;
    public Transform ff;

    // Start is called before the first frame update
    private void Start()
    {
        /* transform.Rotate(0, Time.deltaTime * Speed, 0);*/
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * Speed, 0);
    }
}