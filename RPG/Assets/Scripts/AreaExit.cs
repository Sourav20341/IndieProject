using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string levelname;
    public string TransitionName;
    public float waittoload = 1f;
    public bool shouldload;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldload)
        {
            waittoload -= Time.deltaTime;
            if(waittoload <= 0)
            {
                SceneManager.LoadScene(levelname);
                shouldload = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            shouldload = true;
            UIImage.instance.fadeToblack();
            PlayerController.instance.TransitionName = TransitionName;
        }
    }
}
