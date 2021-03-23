using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(player.forward);
    }
}