using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollided : MonoBehaviour
{
    bool isCollided = false;
    
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag != "Bullet" && col.gameObject.tag != "Player" && !isCollided){
            Destroy(gameObject);
            isCollided = true;
        }
    }
}
