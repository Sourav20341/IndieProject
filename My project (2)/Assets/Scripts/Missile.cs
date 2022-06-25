using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public Transform target;
    public bool isFound = false;

    public GameObject ExplosionEffect;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null){
        transform.position = Vector3.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(target.position,transform.up);
        }
        if(isFound && transform.position == target.position){
            Destroy(gameObject);
            Destroy(target.gameObject);
            GameObject game = Instantiate(ExplosionEffect,target.position,Quaternion.identity) as GameObject;
            Destroy(game,5);
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == 6 && isFound == false){
            target = other.gameObject.transform;
            isFound = true;
        }
    }
}
