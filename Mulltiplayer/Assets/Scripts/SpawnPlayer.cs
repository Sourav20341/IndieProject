using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPref;
    private  GameObject player;
    public static SpawnPlayer instance;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsConnected){
            spawn();
        }
    }

    void spawn(){
        Transform Point = SpawnPoint.instance.GetTransform();
        player = PhotonNetwork.Instantiate(playerPref.name,Point.position,Point.rotation);
        Debug.Log(playerPref.name);
    }
}
