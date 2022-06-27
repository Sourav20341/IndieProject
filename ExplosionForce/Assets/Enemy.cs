using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Player;
    public float timer = 5;
    public float current = 0;
    public GameObject bullet;
    public float force = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        current += Time.unscaledDeltaTime;
        if(current >= timer){
            current = 0;
            shoot();
        }
    }
    void shoot(){
        GameObject g = Instantiate(bullet,firepoint.position,Quaternion.identity);
        Vector3 dir = Player.transform.position - firepoint.position;
        dir.Normalize();
        g.GetComponent<Rigidbody>().AddForce(dir*force,ForceMode.Impulse);
    }
}
