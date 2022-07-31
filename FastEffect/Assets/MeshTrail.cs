using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    public float trailtime = 2f;
    public Transform position;
    public float refreshrate = 0.1f;
    private bool activetrail = false;
    public Material mat;
    public float destroyTime = 3f;
    public string shadervarref;
    public float shaderrate = 0.1f;
    private SkinnedMeshRenderer[] meshRenderers;
    public float matrefreshrate = 0.05f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !activetrail){
            activetrail = true;
            StartCoroutine(Activate(trailtime));
        }
    }

    IEnumerator Activate(float time){
        while(time > 0){
            time -= refreshrate;
            if(meshRenderers == null){
                meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            }
            for(int i = 0;i<meshRenderers.Length;i++){
                GameObject obj = new GameObject();
                obj.transform.SetPositionAndRotation(position.position,position.rotation);
                obj.AddComponent<MeshRenderer>();
                obj.AddComponent<MeshFilter>();
                Mesh mesh = new Mesh();
                meshRenderers[i].BakeMesh(mesh);
                obj.GetComponent<MeshFilter>().mesh = mesh;
                obj.GetComponent<MeshRenderer>().sharedMaterial = mat;
                StartCoroutine(AnimateShader(0,matrefreshrate,shaderrate,obj.GetComponent<MeshRenderer>().material));
                Destroy(obj,destroyTime);
            }
            yield return new WaitForSeconds(refreshrate);
        }
        activetrail = false;
    }
    IEnumerator AnimateShader(int goal,float matrefreshrate,float rate,Material mat){
        float currval = mat.GetFloat(shadervarref);
        while(currval > goal){
            currval -= rate;
            mat.SetFloat(shadervarref,currval);
            yield return new WaitForSeconds(matrefreshrate);
        }
    }
}
