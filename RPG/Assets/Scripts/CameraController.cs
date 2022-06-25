using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform TARGET;
    public Tilemap tilemap;
    private Vector3 bottomleft;
    private Vector3 topright;
    private float halfwidth;
    private float halfheight;
    // Start is called before the first frame update
    void Start()
    {
        TARGET = PlayerController.instance.transform;
        halfheight = Camera.main.orthographicSize;
        halfwidth = Camera.main.aspect * halfheight;
        bottomleft = tilemap.localBounds.min + new Vector3(halfwidth,halfheight,0);
        topright = tilemap.localBounds.max + new Vector3(-halfwidth,-halfheight,0);
        PlayerController.instance.setBounds(tilemap.localBounds.min, tilemap.localBounds.max);    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(TARGET.position.x, TARGET.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomleft.x, topright.x), Mathf.Clamp(transform.position.y, bottomleft.y, topright.y), transform.position.z);
    }
}
