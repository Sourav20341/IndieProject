using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    public PlayerStats[] charstats;
    public TextMeshProUGUI[] playernames, HP, MP, Exp, Level, expslider;
    public Image[] images;
    public Slider[] sliders;
    public GameObject[] statHolder;
    public GameObject[] windows;

    public GameObject[] statsButtons;

    public Image statusImage;
    public TextMeshProUGUI playername,hp,mp,equippedwpn,wpnpower,equippedarm,strength,defence,armorpwr,exptonext;
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (!menu.activeInHierarchy)
            {
                UpdateStats();
                PlayerController.instance.canMove = false;
                menu.SetActive(true);
            }
        }
    }

    void UpdateStats()
    {
        charstats = GameManager.instance.stats;
        for(int i = 0; i < charstats.Length; i++)
        {
            if (charstats[i].gameObject.activeInHierarchy)
            {
                statHolder[i].SetActive(true);
                playernames[i].text = charstats[i].charname;
                HP[i].text = "HP: " + charstats[i].currHP + "/" + charstats[i].maxHP;
                MP[i].text = "MP: " + charstats[i].currentMP + "/" + charstats[i].maxMP;
                Level[i].text = "Level: " + charstats[i].charlevel;
                sliders[i].maxValue = charstats[i].addToExp[charstats[i].charlevel];
                sliders[i].value = charstats[i].currentExp;
                expslider[i].text = "" + sliders[i].value + "/" + sliders[i].maxValue+"";
                images[i].sprite = charstats[i].charImage;
            }
            else
            {
                statsButtons[i].SetActive(false);
                statHolder[i].SetActive(false);
            }
        }
    }

    public void switchWindow(int n)
    {
        UpdateStats();
        for(int i = 0; i < windows.Length; i++)
        {
            if(i == n)
            {
                if (windows[i].activeInHierarchy)
                {
                    windows[i].SetActive(false);
                }
                else
                {
                    windows[i].SetActive(true);
                }
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void closeMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
            PlayerController.instance.canMove = true;
            menu.SetActive(false);
        }
    }

    public void openStats(){
        UpdateStats();
        for(int i = 0 ;i<charstats.Length;i++){
            statsButtons[i].gameObject.SetActive(charstats[i].gameObject.activeInHierarchy);
            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = charstats[i].charname;
        }
    }

    public void statusviewer(int n){
        for(int i = 0;i<statsButtons.Length;i++){
            if(i==n){
                statusImage.sprite = images[i].sprite;
                equippedwpn.text = charstats[i].wpnname;
                equippedarm.text = charstats[i].armorname;
                playername.text = charstats[i].charname;
                hp.text = ""+charstats[i].currHP + "/" + charstats[i].maxHP;;
                mp.text = ""+charstats[i].currentMP + "/" + charstats[i].maxMP;;
                defence.text = charstats[i].defence.ToString();
                strength.text = charstats[i].strength.ToString();
                wpnpower.text = charstats[i].wpnpwr.ToString();
                armorpwr.text = charstats[i].armorpwr.ToString();
                exptonext.text = expslider[i].text;
            }
        }
    }
}
