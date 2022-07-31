using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uprleja : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.down*speed*Time.fixedDeltaTime;
        rb.MovePosition(rb.position);
    }
}
