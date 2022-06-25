using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDroneMovement : MonoBehaviour
{
    public Vector3 target;
    public float velocity;
    public bool isreverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null && !isreverse){
            transform.position = Vector3.Lerp(transform.position,target,Time.deltaTime*velocity);
        }
        if(target != null && isreverse){
            transform.position = Vector3.Lerp(transform.position,target,velocity*Time.deltaTime);
        }
    }
}
