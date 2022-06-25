using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShader : MonoBehaviour
{
    public Material material;
    bool forward = false;
    public float speed = 0.2f;
    public Collider2D collider1;
    public Collider2D collider2;
    // Update is called once per frame
    void Update()
    {   
        if(material.GetFloat("_Fade") <= 0 && !forward)
        {
            collider1.enabled = true;
            collider2.enabled = true;
            forward = true;
        }
        if(material.GetFloat("_Fade") >= 1 && forward)
        {
            collider1.enabled = false;
            collider2.enabled = false;
            forward = false;
        }
        if (forward)
        {
            material.SetFloat("_Fade", material.GetFloat("_Fade")+ Time.deltaTime*speed);
        }
        if (!forward)
        {
            material.SetFloat("_Fade", material.GetFloat("_Fade") - Time.deltaTime*speed);
        }
    }
}
