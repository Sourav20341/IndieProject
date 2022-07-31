using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rokle : MonoBehaviour
{
    public BoxCollider col;
    public bool krdiya = false;

    void OnTriggerEnter(Collider col){
        if(col.tag == "Climb"){
            krdiya = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    void Update(){
        if(krdiya){
            col.isTrigger = false;
        }
    }
}
