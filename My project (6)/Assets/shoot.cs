using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject projectile;
    public float force = 10f;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            GameObject g = Instantiate(projectile,transform.position,Quaternion.identity);
            Vector3 dir = (transform.position - enemy.position).normalized;
            g.GetComponent<Rigidbody>().AddForce(force*-dir,ForceMode.VelocityChange);
        }
    }
}
