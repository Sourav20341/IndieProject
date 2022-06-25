using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Wrap : MonoBehaviour
{
    public VisualEffect vfx;
    public float refreshrate = 0.01f;
    public float amountrate = 0.02f;
    bool isWrap = false;

    // Start is called before the first frame update
    void Start()
    {
        vfx.Stop();
        vfx.SetFloat("WrapAmount",0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            isWrap = true;
            StartCoroutine(AllParticles());
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            isWrap = false;
            StartCoroutine(AllParticles());
        }
    }

    IEnumerator AllParticles(){
        if(isWrap){
            vfx.Play();
            float amount = vfx.GetFloat("WrapAmount");
            while(amount < 1 && isWrap){
                amount += amountrate;
                vfx.SetFloat("WrapAmount",amount);
                yield return new WaitForSeconds(refreshrate);
            }
        }
        else{
            float amount = vfx.GetFloat("WrapAmount");
            while(amount >= 0 && !isWrap){
                amount -= amountrate;
                vfx.SetFloat("WrapAmount",amount);
                yield return new WaitForSeconds(refreshrate);
                if(amount < 0){
                    amount = 0;
                    vfx.SetFloat("WrapAmount",amount);
                    vfx.Stop();
                }
            }
        }
    }
}
