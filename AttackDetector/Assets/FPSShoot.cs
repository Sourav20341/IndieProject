using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Camera camera;
    public Transform LeftFirepoint;
    public Transform RightFirePoint;
    private bool isLeft;
    public Vector3 Destination;
    public int firerate = 4;
    public float timeTofire = 0;
    
    public float projectileSpeed = 30;
    public float arcRange = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeTofire){
            timeTofire = Time.time + 1f/firerate;
            Shoot();
        }
    }
    void Shoot(){
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)){
            Destination = hit.point;
        }
        else{
            Destination = ray.GetPoint(1000);
        }
        if(isLeft){
            InstantationProjectile(LeftFirepoint);
            isLeft = false;
        }
        else{
            InstantationProjectile(RightFirePoint);
            isLeft = true;
        }
    }
    void InstantationProjectile(Transform position){
        var projectileObj = Instantiate(BulletPrefab,position.position,Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (Destination - position.position).normalized * projectileSpeed;
        iTween.PunchPosition(projectileObj,new Vector3(Random.Range(arcRange,arcRange),Random.Range(arcRange,arcRange),0),Random.Range(0.5f,2f));
    }
}
