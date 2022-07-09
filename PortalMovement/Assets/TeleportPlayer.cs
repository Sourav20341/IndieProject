using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    public bool isplayerOverlap = false;
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            player.position = reciever.position;
            isplayerOverlap = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            isplayerOverlap = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isplayerOverlap){
            player.position = reciever.position;
        }
        // if(isplayerOverlap){
        //     Vector3 portalToPlayer = player.position - transform.position;
        //     float dot = Vector3.Dot(transform.up,portalToPlayer);
        //     if(dot < 0){
        //         float rotationDiff = -Quaternion.Angle(transform.rotation,reciever.rotation);
        //         rotationDiff+=180;
        //         player.Rotate(Vector3.up,rotationDiff);
        //         Vector3 direction = Quaternion.Euler(0,rotationDiff,0)*portalToPlayer;
        //         player.position = reciever.position+direction;
        //         isplayerOverlap = false;
        //     }
        // }
    }
}
