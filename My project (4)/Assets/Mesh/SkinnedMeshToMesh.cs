using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class SkinnedMeshToMesh : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public VisualEffect VFX;
    public float refreshRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateVfxGraph());
    }

    // Update is called once per frame
    IEnumerator UpdateVfxGraph(){
        while(gameObject.activeSelf){
            Mesh m = new Mesh();
            skinnedMeshRenderer.BakeMesh(m);
            Mesh m2 = new Mesh();
            Vector3[] vertice = m.vertices;
            m2.SetVertices(vertice);
            VFX.SetMesh("MainMesh",m);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
