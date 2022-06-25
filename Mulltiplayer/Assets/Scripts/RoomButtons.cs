using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomButtons : MonoBehaviour
{
    public TextMeshProUGUI text;
    private RoomInfo info;
    public void SetButtonDetails(RoomInfo inf){
        info = inf;
        text.text = inf.Name; 
    }

    public void OpenRoom(){
        Launcher.instance.joinRoom(info);
    }
}
