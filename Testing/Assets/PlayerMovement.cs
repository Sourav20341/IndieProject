using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public Transform cameraPoint;
    public Camera cam;
    public float sensitivity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            if(Physics.Raycast(ray,out RaycastHit hit)){
                Power.instance.Release(hit.point);
            }
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 pos = transform.right*x  + transform.forward*y;
        rb.MovePosition(rb.position + pos*speed*Time.deltaTime);
        float yrot = Input.GetAxisRaw("Mouse X");
        Quaternion deltarot = Quaternion.Euler(0,yrot*sensitivity*Time.deltaTime,0);
        rb.MoveRotation(rb.rotation * deltarot);
    }

    void LateUpdate(){
        cam.transform.position = cameraPoint.position;
        cam.transform.rotation = cameraPoint.rotation;
    }
}
