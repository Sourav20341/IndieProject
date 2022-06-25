using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject rb;
    public bool called = false;
    public static Power instance;

    List <GameObject> currentCollisions = new List <GameObject> ();

    void Awake(){
        instance = this;
    }
    void Update()
    {
        if(called){
            CallPower();
        }
        if(Input.GetKeyDown(KeyCode.P)){
            foreach(GameObject g in currentCollisions){
                g.GetComponent<Rigidbody>().useGravity = false;
                 Vector3 pos = (transform.position - g.transform.position).normalized;
                g.transform.position = new Vector3(pos.x*8,Random.RandomRange(0.25f,1),pos.z*8);
            }
            called = true;
        }
    }

    public void Release(Vector3 point){
        foreach(GameObject g in  currentCollisions){
            Vector3 pos = (point - g.transform.position).normalized;
            g.GetComponent<Rotation>().isRotate = false;
            g.GetComponent<Rigidbody>().AddForce(pos*50,ForceMode.Impulse);   
        }
        currentCollisions.Clear();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.layer == 3){
            currentCollisions.Add (col.gameObject);
         }
    }
    void CallPower(){
        foreach(GameObject g in currentCollisions){
            g.GetComponent<Rotation>().isRotate = true;
        }
        
    }
}
