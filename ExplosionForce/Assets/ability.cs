using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += (1f / timer )*Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0,1);
        if(Input.GetKeyDown(KeyCode.C)){
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime =Time.timeScale * 0.02f;
        }   
    }
}
