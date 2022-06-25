using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint instance;

    void Awake(){
        instance = this;
    }
    public Transform[] points;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<points.Length;i++){
            points[i].gameObject.SetActive(false);
        }
    }

    public Transform GetTransform(){
        return points[Random.Range(0,points.Length)];
    }
}
