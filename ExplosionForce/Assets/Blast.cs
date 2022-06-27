using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public Collider[] colliders;
    public float timer;
    public float Explosiveforce;
    public float radius;
    public bool hasExploded = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasExploded){
            hasExploded = true;
            StartCoroutine(startCount(timer));
        }
    }
    IEnumerator startCount(float timer){
        yield return new WaitForSeconds(timer);
            colliders = Physics.OverlapSphere(transform.position,radius);
            foreach(Collider col in colliders){
                Rigidbody r = col.gameObject.GetComponent<Rigidbody>();
                if(r != null){
                    r.AddExplosionForce(Explosiveforce,transform.position,radius);
                }
            }
    }
}
