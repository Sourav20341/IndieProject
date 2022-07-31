using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krdetrue : MonoBehaviour
{
    public Chdja chd;
    void OnTriggerEnter(Collider col){
        if(col.tag == "Climb"){
            chd.isclose = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Climb"){
            chd.isclose = false;
        }
    }
}
