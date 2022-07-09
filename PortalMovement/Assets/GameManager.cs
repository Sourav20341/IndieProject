using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cameraB;
    public Material portalMat;
    // Start is called before the first frame update
    void Start()
    {
        if(cameraB.targetTexture != null){
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        portalMat.mainTexture = cameraB.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
