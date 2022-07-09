using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int FPS = 120;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;

    float yRotation;
    float xRotation;
    float lookSensitivity = 2;
    float currentXRotation;
    float currentYRotation;
    float yRotationV;
    float xRotationV;
    float lookSmoothness = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = FPS;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        if(characterController.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if(Input.GetButtonDown("Jump")){
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity*Time.deltaTime;
        characterController.Move(moveDirection*Time.deltaTime);

        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation,-80,100);
        currentXRotation = Mathf.SmoothDamp(currentXRotation,xRotation,ref xRotationV,lookSmoothness);
        currentYRotation = Mathf.SmoothDamp(currentYRotation,yRotation,ref yRotationV,lookSmoothness);
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

    }
}
