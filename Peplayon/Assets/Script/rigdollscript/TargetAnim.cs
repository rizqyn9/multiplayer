using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnim : MonoBehaviour
{
    public Transform targetAnim;
    public bool mirror;
    private ConfigurableJoint joint;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if (!mirror)
        {
            joint.targetRotation = targetAnim.rotation;
        }
        else
        {
            joint.targetRotation = Quaternion.Inverse(targetAnim.rotation);
        }
    }
}