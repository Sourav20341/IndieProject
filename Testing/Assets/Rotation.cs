using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool isRotate = false;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if(isRotate){
            float x = Random.RandomRange(0.15f,0.25f);
            float z = Random.RandomRange(0.15f,0.25f);
            transform.RotateAround(target.transform.position,new Vector3(x,1,z),240*Time.deltaTime);
        }
    }
}
