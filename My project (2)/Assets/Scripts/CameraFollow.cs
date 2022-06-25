using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Target.position;
        transform.rotation = Target.rotation;
    }
}
