using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byouncy : MonoBehaviour
{
    public Transform[] floaters;
    public float underwaterdrag = 3f;
    public float underwaterangulardrag = 1f;
    public float airdrag = 0f;
    public float floatingpower = 15f;
    public float airangulardrag = 0.05f;
    public Rigidbody m_Rigidbody;
    bool underwater = false;
    public float height;
    int underwatercount = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        underwatercount = 0;
        for(int i = 0;i<floaters.Length;i++){
            float difference = floaters[i].position.y - height;
            if(difference < 0){
                m_Rigidbody.AddForceAtPosition(Vector3.up*floatingpower*Mathf.Abs(difference),floaters[i].position,ForceMode.Force); 
                underwatercount++;
                if(!underwater){
                    underwater = true;
                    SwitchState(underwater);
                }
            }
        }
        if(underwater && underwatercount == 0){
                underwater = false;
                SwitchState(underwater);
        }
    }

    void SwitchState(bool under){
        if(under){
            m_Rigidbody.angularDrag = underwaterangulardrag;
            m_Rigidbody.drag = underwaterdrag;
        }
        else{
            m_Rigidbody.angularDrag = airangulardrag;
            m_Rigidbody.drag = airdrag;
        }
    }
}
