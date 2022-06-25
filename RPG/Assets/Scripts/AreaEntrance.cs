using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string TransitionName;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance.TransitionName == TransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
        UIImage.instance.fadeFromblack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
