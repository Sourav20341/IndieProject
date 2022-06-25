using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController character;
    public Transform pickupoint;
    public Transform dropPoint;
    public GameObject found;
    public float speed;
    public Transform Eyes;
    public Camera fpsCam;
    public float sensitivityX;
    public float sensitivityY;

    public float force = 10;

    public GameObject Missile;

    public Transform FirePoint;
    public float MissileVelocity;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            GameObject game = Instantiate(Missile,FirePoint.position,Eyes.rotation); 
            game.GetComponent<Rigidbody>().velocity = MissileVelocity*Eyes.forward;
        }
        if(found != null){
            found.transform.position = pickupoint.position;
            found.transform.rotation = pickupoint.rotation;
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q) && found != null){
            found.GetComponent<Rigidbody>().AddForce(dropPoint.forward*force,ForceMode.Impulse);
            found.GetComponent<Rigidbody>().useGravity = true;
            found = null;
        }
        if(Input.GetKeyDown(KeyCode.Q) && found != null){
            found.transform.position = dropPoint.position;
            found.transform.rotation = dropPoint.rotation;
            found.GetComponent<Rigidbody>().useGravity =true;
            found = null;
        }
        if(Input.GetKeyDown(KeyCode.P)){
            RaycastHit ray;
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            Physics.Raycast(rayOrigin,fpsCam.transform.forward,out ray);
            if(ray.collider != null && ray.collider.gameObject.layer == 3){
                found = ray.collider.gameObject;
                found.GetComponent<Rigidbody>().useGravity = false;
            }
        }
        Vector3 x = Input.GetAxis("Horizontal") * transform.right;
        Vector3 z = Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveInput = x + z;
        moveInput.Normalize();
        character.Move(moveInput * speed * Time.deltaTime);
        Vector3 rotateInput = new Vector3(-Input.GetAxis("Mouse Y")*sensitivityY,Input.GetAxis("Mouse X")*sensitivityX,0);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y + rotateInput.y,transform.rotation.eulerAngles.z));
        Eyes.rotation = Quaternion.Euler(new Vector3(Eyes.rotation.eulerAngles.x + rotateInput.x,Eyes.rotation.eulerAngles.y,Eyes.rotation.eulerAngles.z));
    }
}
