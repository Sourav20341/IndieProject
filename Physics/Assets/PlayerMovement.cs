using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    private CharacterController characterController;
    //public Rigidbody rb;
    public float speed = 10f;
    public float xSensi = 5f;
    public float ySensi = 3f;
    public Transform cameraPoint;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = (x*transform.right + y*transform.forward);
        Vector3 move = movement.normalized;
        move *= speed*Time.unscaledDeltaTime;
        characterController.Move(move);
        float xRot = Input.GetAxisRaw("Mouse X");
        transform.Rotate(0,xRot*xSensi,0);
        float yRot = Input.GetAxisRaw("Mouse Y");
        cameraPoint.transform.Rotate(-yRot*ySensi,0,0);

        if(Input.GetKeyDown(KeyCode.V)){
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Time.timeScale = 1;
        }
    }

    // void FixedUpdate(){
    //     if(Input.GetKeyDown(KeyCode.P)){
    //         // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
    //         // if(Physics.Raycast(ray,out RaycastHit hit)){
    //         //     if(hit.collider.gameObject.layer == 3){
    //         //         Debug.Log("HIT");
    //         //         //characterController.enabled = false;
    //         //         if(gameObject.GetComponent<SpringJoint>() != null){
    //         //             Destroy(gameObject.GetComponent<SpringJoint>());
    //         //         }
    //         //         SpringJoint springJoint =  gameObject.AddComponent<SpringJoint>();
    //         //         springJoint.autoConfigureConnectedAnchor = false;
    //         //         springJoint.connectedAnchor = hit.point;
    //         //     }
    //         // }
    //         if(Physics.SphereCast(transform.position,10,transform.forward,out RaycastHit hit,10)){
    //             Debug.Log(hit.collider.name);
    //         }
    //     }
    // }

    void LateUpdate(){
        cam.transform.position = cameraPoint.position;
        cam.transform.rotation = cameraPoint.rotation;
    }

}
