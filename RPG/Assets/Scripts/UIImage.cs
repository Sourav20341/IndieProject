using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIImage : MonoBehaviour
{
    public static UIImage instance;
    public Image image;
    public float fadespeed;
    private bool fadetoblack;
    private bool fadefromblack;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadetoblack)
        {
            image.color = new Color(image.color.r, image.color.b, image.color.g, 
                Mathf.MoveTowards(image.color.a, 1f, fadespeed * Time.deltaTime));
            if(image.color.a == 1f)
            {
                fadetoblack = false;
            }
        }
        if (fadefromblack)
        {
            image.color = new Color(image.color.r, image.color.b, image.color.g, 
                Mathf.MoveTowards(image.color.a, 0, fadespeed * Time.deltaTime));
            if(image.color.a == 0)
            {
                fadefromblack = false;
            }
        }
    }

    public void fadeToblack()
    {
        fadetoblack = true;
        fadefromblack = false;
    }
    public void fadeFromblack()
    {
        fadetoblack = false;
        fadefromblack = true;
    }
}
