using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chdja : MonoBehaviour
{
    public bool isclose = false;
    public bool climbed = false;
    public Rigidbody rb;
    public float speed = 10f;    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if(isclose && Input.GetKeyDown(KeyCode.C) && !climbed){
            climbed = true;
        }
        if(!isclose){
            climbed = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isclose && climbed){
            if(Input.GetKey(KeyCode.UpArrow)){
                rb.MovePosition(new Vector3(rb.position.x,rb.position.y + speed*Time.fixedDeltaTime,rb.position.z));
            }
        }
    }
}
