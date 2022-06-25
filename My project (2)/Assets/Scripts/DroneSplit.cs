using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSplit : MonoBehaviour
{
    public Transform[] DroneFollow;
    public GameObject subDrone;
    public Vector3 offset;
    public float velocity;
    public GameObject[] refernces;
    public bool splitted = false;

    void Start(){
        refernces = new GameObject[DroneFollow.Length];
    }

    // Start is called before the first frame updat
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y) && !splitted){
            for(int i = 0;i<DroneFollow.Length;i++){
                Vector3 pos = DroneFollow[i].position + offset;
                GameObject game = Instantiate(subDrone,transform.position,transform.rotation);
                game.GetComponent<SubDroneMovement>().velocity = velocity;
                game.GetComponent<SubDroneMovement>().target = pos;
                game.GetComponent<SubDroneMovement>().isreverse= false;
                refernces[i] = game;
                splitted = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && splitted){
            for(int i = 0;i<DroneFollow.Length;i++){
                refernces[i].GetComponent<SubDroneMovement>().target = transform.position;
                refernces[i].GetComponent<SubDroneMovement>().isreverse = true;
                splitted = false;
            }
        }
    }
}
