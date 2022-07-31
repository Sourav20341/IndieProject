using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bachle : MonoBehaviour
{
    public Transform shooter;
    public int prev = -1;
    public float distance = 10f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col){
        if(col.gameObject.layer == 3){
            Dodge();
        }
    }

    void Dodge(){
        int random = Random.Range(1,8);
        if(prev != -1){
            while(random == prev){
                random = Random.Range(1,8);
            }
        }
        prev =random;
        float theta = 2*Mathf.PI;
        float y = distance*Mathf.Sin(theta/random);
        float x = distance*Mathf.Cos(theta/random);
        transform.position = new Vector3(x+shooter.position.x,transform.position.y,y+shooter.position.z);
    }
}
