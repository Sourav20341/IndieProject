using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;
public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;
    public GameObject menuButtons;
    public GameObject loadingScreen;
    public TextMeshProUGUI loadingText;
    public GameObject RoomSearch;
    public TMP_InputField txt;
    public GameObject RoomScreen;
    public TextMeshProUGUI roomName;
    public GameObject errorScrren;
    public TextMeshProUGUI errormessage;
    public RoomButtons roomButon;
    public GameObject BrowsingScreen;
    private List<RoomButtons> allrooms = new List<RoomButtons>(); 
    private List<TMP_Text> allPlayers = new List<TMP_Text>();
    public TMP_Text playerName;
    public TMP_InputField inputName; 
    public GameObject inputScreen;
    public bool hasNick = false;
    public string levelToLoad;

    public GameObject startButton;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CloseMenus();
        loadingScreen.SetActive(true);
        loadingText.text = "Conecting to Networking..."; 
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();
        loadingText.text = "Joining Lobby...";
    }

    public override void OnJoinedLobby()
    {
        CloseMenus();
        menuButtons.SetActive(true);
        PhotonNetwork.NickName = Random.Range(0,1000).ToString();
        if(!hasNick){
            CloseMenus();
            inputScreen.SetActive(true);
            if(PlayerPrefs.HasKey("playerName")){
                inputName.text = PlayerPrefs.GetString("playerName");
            }
        }
        else{
            PhotonNetwork.NickName = PlayerPrefs.GetString("playerName");
        }
    }

    void CloseMenus(){
        BrowsingScreen.SetActive(false);
        errorScrren.SetActive(false);
        RoomSearch.SetActive(false);
        menuButtons.SetActive(false);
        loadingScreen.SetActive(false);
        RoomScreen.SetActive(false);
        inputScreen.SetActive(false);
    }

    public void CREATEROOM(){
        CloseMenus();
        RoomSearch.SetActive(true);
    }

    public void startgame(){
        PhotonNetwork.LoadLevel(levelToLoad);
    }

    public void ROOMCREATION(){
        if(!string.IsNullOrEmpty(txt.text)){
            RoomOptions option = new RoomOptions();
            option.MaxPlayers = 6;
            PhotonNetwork.CreateRoom(txt.text,option);
            CloseMenus();
            loadingScreen.SetActive(true);
            loadingText.text = "Creating Room...";
        }
    }

    public override void OnCreatedRoom()
    {
        CloseMenus();
        RoomScreen.SetActive(true);
        roomName.text = txt.text;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CloseMenus();
        errorScrren.SetActive(true);
        errormessage.text = "Failed to Create Room : " + message;
    }

    public void closeError(){
        CloseMenus();
        menuButtons.SetActive(true);
    }

    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
        CloseMenus();
        loadingScreen.SetActive(true);
        loadingText.text = "Loading...";
    }

    public override void OnLeftRoom()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }

    public void OpenBrowsingScreen(){
        CloseMenus();
        BrowsingScreen.SetActive(true);
    }

    public void CloseBrowsingScreen(){
        CloseMenus();
        menuButtons.SetActive(true);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomButtons r in allrooms){
            Destroy(r.gameObject);
        }
        allrooms.Clear();
        roomButon.gameObject.SetActive(false);
        for(int i = 0;i<roomList.Count;i++){
            if(roomList[i].PlayerCount < roomList[i].MaxPlayers && !roomList[i].RemovedFromList){
                RoomButtons newButton = Instantiate(roomButon,roomButon.transform.parent);
                newButton.SetButtonDetails(roomList[i]);
                newButton.gameObject.SetActive(true);
                allrooms.Add(newButton);
            }
        }
    }

    public void joinRoom(RoomInfo info){
        PhotonNetwork.JoinRoom(info.Name);
        CloseMenus();
        loadingScreen.SetActive(true);
        loadingText.text = "Joining Room...";
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.IsMasterClient){
            startButton.SetActive(true);
        }
        else{
            startButton.SetActive(false);
        }
        CloseMenus();
        RoomScreen.SetActive(true);
        roomName.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayers();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if(PhotonNetwork.IsMasterClient){
            startButton.SetActive(true);
        }
        else{
            startButton.SetActive(false);
        }
    }

    public void Quitgame(){
        Application.Quit();
    }

    public void UpdatePlayers(){
        foreach(TMP_Text t in allPlayers){
            Destroy(t.gameObject);
        }
        allPlayers.Clear();
        Player[] pl = PhotonNetwork.PlayerList;
        playerName.gameObject.SetActive(false);
        for(int i = 0;i<pl.Length;i++){
            TMP_Text player = Instantiate(playerName,playerName.transform.parent);
            player.text = pl[i].NickName;
            player.gameObject.SetActive(true);
            allPlayers.Add(player);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        TMP_Text player = Instantiate(playerName,playerName.transform.parent);
            player.text = newPlayer.NickName;
            player.gameObject.SetActive(true);
            allPlayers.Add(player);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayers();
    }

    public void EnterName(){
        if(!string.IsNullOrEmpty(inputName.text)){
            PhotonNetwork.NickName = inputName.text;
            PlayerPrefs.SetString("playerName",inputName.text);
            hasNick = true;
            CloseMenus();
            menuButtons.SetActive(true);
        }
    }
}
