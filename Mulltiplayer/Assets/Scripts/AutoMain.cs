using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class AutoMain : MonoBehaviour
{
    public static AutoMain instance;
    void Awake(){
        instance = this;
    }
    // Update is called once per frame
    void Start()
    {
        if(!PhotonNetwork.IsConnected){
            SceneManager.LoadScene(0);
        }
    }
}
