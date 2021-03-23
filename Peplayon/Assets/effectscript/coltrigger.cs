using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coltrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject collision;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Object"))
        {
            Debug.Log("coll");
            Instantiate(collision, transform.position, transform.rotation);
        }
    }
}