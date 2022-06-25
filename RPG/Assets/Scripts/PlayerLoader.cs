using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance == null)
        {
            Instantiate(Player,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
