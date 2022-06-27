using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    bool isRewinding = false;
    List<Pair>position;
    public Rigidbody rb;
    public float time = 5f;
    void Start(){
        rb = GetComponent<Rigidbody>();
        position = new List<Pair>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            startRewind();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            stopRewind();
        }
    }
    void Record(){
        if(position.Count > Mathf.Round(time / Time.fixedDeltaTime)){
            position.RemoveAt(position.Count-1);
        }
        position.Insert(0,new Pair(transform.position,transform.rotation));
    }
    void DoRewind(){
        if(position.Count > 0){
            transform.position =position[0].position;
            transform.rotation = position[0].rotation;
            position.RemoveAt(0);
        }
        else{
            stopRewind();
        }
    }
    void FixedUpdate(){
        if(isRewinding){
            DoRewind();
        }
        else{
            Record();
        }
    }
    void startRewind(){
        isRewinding = true;
        rb.isKinematic = true;
    }

    void stopRewind(){
        isRewinding = false;
        rb.isKinematic = false;
    }
}
class Pair{
    public Vector3 position;
    public Quaternion rotation;
    public Pair(Vector3 pos,Quaternion rot){
        position = pos;
        rotation = rot;
    }
}
