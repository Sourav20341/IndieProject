using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherportal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = playerCamera.position - otherportal.position;
        transform.position = portal.position + difference;
        float angulardiffernce = Quaternion.Angle(portal.rotation,otherportal.rotation);
        Quaternion angle = Quaternion.AngleAxis(angulardiffernce,Vector3.up);
        Vector3 newcameraRotation = angle * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newcameraRotation,Vector3.up);
    }
}
