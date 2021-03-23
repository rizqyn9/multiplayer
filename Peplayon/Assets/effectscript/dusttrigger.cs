using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wahyu;

public class dusttrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject dust;

    [SerializeField]
    private GameObject dust2;

    public bool grounded;
    public bool coroutineAlowed;

    private void Start()
    {
    }

    private void Update()
    {
        if (grounded && wahyu.Motion.blend > 0 && coroutineAlowed)
        {
            StartCoroutine("spawndust");
            coroutineAlowed = false;
        }
        if (wahyu.Motion.blend <= 0 || !grounded)
        {
            StopCoroutine("spawndust");
            coroutineAlowed = true;
        }
    }

    private IEnumerator spawndust()
    {
        while (grounded)
        {
            Instantiate(dust2, transform.position, dust2.transform.rotation);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("groond");
            Instantiate(dust, transform.position, transform.rotation);
            grounded = true;
            coroutineAlowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            coroutineAlowed = false;
            grounded = false;
        }
    }
}