using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Material mat;
    private NavMeshAgent nav;
    private GameObject player;
    public float spawner = 6f;
    public bool onetime = false;
    public bool power = false;
    public float speed = 1f;
    public bool doColor = false;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.layer == 3){
            player = col.gameObject;
        }
    }
    void Update()
    {
        if(doColor){
            if(mat.color.g > 0){
                ChangeColor();
            }
            else{
                Color color1 = new Color(4,0,0);
                mat.SetColor("_EmissionColor",color1);
                doColor = false;
            }
        }
        if(player != null){nav.SetDestination(player.transform.position);}
        if(player != null && !onetime){
            
            power = true;
        }
        if(power){
            power = false;
            onetime = true;
            StartCoroutine(showTime());
            doColor = true;
        }

    }
    void ChangeColor(){
        Debug.Log(Time.deltaTime);
        Color color = new Color(mat.color.r,mat.color.g - Time.deltaTime*speed,mat.color.b - Time.deltaTime*speed,mat.color.a);
        mat.SetColor("_BaseColor",color);
        
    }
    void CallPower(){
        for(int  i = 0;i<spawner;i++){
            float angle = 2*Mathf.PI*i / spawner;
            float x = 5f * Mathf.Cos(angle);
            float y = 5f * Mathf.Sin(angle);
            Vector3 pos = new Vector3(x,1,y);
            GameObject g = Instantiate(this.gameObject,pos,Quaternion.identity);
            Vector3 p = (player.transform.position - transform.position).normalized;
        }
        Destroy(this.gameObject);
    }

    IEnumerator showTime(){
        yield return new WaitForSeconds(5);
        CallPower();
    }
}
