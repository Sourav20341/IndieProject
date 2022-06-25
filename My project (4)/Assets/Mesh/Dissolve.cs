using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dissolve : MonoBehaviour
{
    public Animator animator;
    public VisualEffect VFX;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float dissolverate;
    public float refreshRate;
    public float dieDelay;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        if(VFX != null){
            VFX.Stop();
            VFX.gameObject.SetActive(false);
        }
        if(skinnedMeshRenderer != null){
            materials = skinnedMeshRenderer.materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("Yes");
            StartCoroutine(dissolve());
        }
    }

    IEnumerator dissolve(){
        if(animator != null){
            animator.SetTrigger("Die");
        }
        yield return new WaitForSeconds(dieDelay);
        if(VFX != null){
            VFX.gameObject.SetActive(true);
            VFX.Play();
        }
        float counter = 0;
        if(materials.Length > 0){
            while(materials[0].GetFloat("_DissolveAmount") < 1){
            counter += dissolverate;
            for(int i = 0;i<materials.Length;i++){
                materials[i].SetFloat("_DissolveAmount",counter);
            }
            yield return new WaitForSeconds(refreshRate);
            }
        }
        Destroy(gameObject,1);
    }
}
