using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 5f;
    public Transform target;
    public float wait = 1f;
    public bool attack = true;
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        if(attack){
            attack = false;
            Vector3 dir = (transform.position - target.position).normalized;
            GameObject obj = Instantiate(bullet,transform.position,Quaternion.identity) as GameObject;
            obj.GetComponent<Rigidbody>().AddForce(-dir*speed,ForceMode.Force);
            StartCoroutine(Stop());
        }
    }
    IEnumerator Stop(){
        yield return new WaitForSeconds(wait);
        attack = true;
    }
}
