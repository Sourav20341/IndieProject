using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform target;
    public float radius = 10f;
    public float refreshrate = 0;
    public float count = 0;
    public float x;
    public float y;
    public bool targetLocked = false;
    public float currentHitDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetLocked){
        refreshrate -= Time.deltaTime;
        if(refreshrate < 0){
        x = Mathf.Cos(transform.position.x * Mathf.PI * 2 * count /6);
        y = Mathf.Sin(transform.position.z * Mathf.PI * 2 * count /6);
        refreshrate = 10;
        count ++;
        if(count >= 6){
            count = 0;
        }
        }
        }
        if(target != null){
            nav.SetDestination(target.position);
            targetLocked = true;
        }
        else{
            nav.SetDestination(new Vector3(x*radius,0,y*radius));
        }
        if(Physics.SphereCast(transform.position,5,transform.forward,out RaycastHit hit,4)){
            if(hit.collider.gameObject.layer == 6){
                target = hit.collider.transform;
                currentHitDistance = hit.distance;
            }
            
        }
        else{
            currentHitDistance = 100;
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position + transform.forward*currentHitDistance);
        Gizmos.DrawWireSphere(transform.position + transform.forward*currentHitDistance,5);
    }
}
