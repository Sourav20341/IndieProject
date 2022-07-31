using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public bool isDiss = false;
    public Material mat;
    public SphereCollider col;
    public float decayRate = 10f;
    public float appearRate = 5f;
    void OnTriggerEnter(Collider other){
        Debug.Log(other.name);
        if(other.tag != "Enemy")
            Disapp();
    }
    void Disapp(){
        isDiss = true;
        col.enabled = false;
        StartCoroutine(AlphaOne());
    }

    void OnTriggerExit(Collider other){
        if(other.tag != "Enemy"){
            app();
        }
        
    }
    void app(){
        isDiss = false;
        col.enabled = true;
        StartCoroutine(AlphaZero());
    }

    IEnumerator AlphaZero(){
        while(mat.GetFloat("_Alpha") > 0 && !isDiss){
            float a = mat.GetFloat("_Alpha");
            a -= Time.deltaTime*decayRate;
            mat.SetFloat("_Alpha",a);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator AlphaOne(){
        while(mat.GetFloat("_Alpha") < 1 && isDiss){
            float a = mat.GetFloat("_Alpha");
            a += Time.deltaTime*appearRate;
            mat.SetFloat("_Alpha",a);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
