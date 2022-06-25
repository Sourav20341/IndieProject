using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public Transform viewPoint;
    public float sensitivity;
    private float verticalStore;
    private Vector2 look;
    private Vector2 moverInput;
    public float runspeed;
    public bool isInverting;
    public float speed;
    public CharacterController characterController;
    private Camera cam;
    private Vector3 movement; 
    public float gravitymod;
    public float jumpforce;
    public LayerMask layer;
    public bool isGrounded;
    public Transform groundCheckPoint;
    public GameObject BulletImpact;
    public float timebetweenshots = 0.1f;
    public TextMeshProUGUI text;
    public float shotCounter = 0;
    public float ammo = 40;
    public bool reloaded = true;
    public GameObject firePoint;
    public float reloadingTime = 5f;
    public Material gunColor;
    public Material fireColor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine){
        if(Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked){
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None){
            Cursor.lockState = CursorLockMode.Locked;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float movespeed;
        if(Input.GetKey(KeyCode.LeftShift)){
            movespeed = runspeed;
        }
        else{
            movespeed = speed;
        }
        moverInput = new Vector2(x,y);
        float yvel = movement.y;
        movement = (transform.forward * y + transform.right*x).normalized*movespeed;
        movement.y  = yvel;
        look = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y")) * sensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y + look.x,transform.eulerAngles.z);
        if(isInverting){
            verticalStore += look.y;
        }
        else{
            verticalStore -= look.y;
        }
        verticalStore = Mathf.Clamp(verticalStore,-60f,60f);
        viewPoint.rotation = Quaternion.Euler(verticalStore,transform.eulerAngles.y,viewPoint.eulerAngles.z);
        if(characterController.isGrounded){
            movement.y = 0;
        }
        isGrounded = Physics.Raycast(groundCheckPoint.position,Vector3.down,0.25f,layer);
        if(Input.GetButtonDown("Jump") && isGrounded){
            movement.y = jumpforce;
        }
        movement.y += Physics.gravity.y*Time.deltaTime*gravitymod; 
        characterController.Move(movement*Time.deltaTime);
        }
    }

    void LateUpdate(){
        if(photonView.IsMine){
            cam.transform.position = viewPoint.transform.position;
            cam.transform.rotation = viewPoint.transform.rotation;
        }
        
    }

    void FixedUpdate(){
        if(photonView.IsMine){
        firePoint.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(gunColor);
        if(ammo <= 0){
            reloaded = false;
        }
        if(!reloaded){
            reloadingTime -= Time.deltaTime;
            if(reloadingTime <= 0){
                reloaded = true;
                reloadingTime = 5f;
                ammo = 40f;
            }
        }
        text.text = ammo.ToString();
        if(Input.GetMouseButton(0) && reloaded){
            firePoint.GetComponent<Renderer>().material.CopyPropertiesFromMaterial(fireColor);
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0){
                Shoot();
            }
        }
        }
    }
    void Shoot(){
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        ray.origin = viewPoint.position;
        if(Physics.Raycast(ray,out RaycastHit hit)){
            GameObject s = Instantiate(BulletImpact,hit.point + hit.normal*(0.002f),Quaternion.LookRotation(hit.normal,Vector3.up));
            Destroy(s,10f);
        }
        ammo--;
        shotCounter = timebetweenshots;  
    }
}
