using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogBox : MonoBehaviour
{
    public static DialogBox instance;
    public GameObject dialogBox;
    public GameObject nameBox;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public string[] dialogs;
    public int currentline = 0;
    public bool juststarted;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (!juststarted)
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    currentline++;
                    if (currentline >= dialogs.Length)
                    {
                        dialogBox.SetActive(false);
                    }
                    else
                    {
                        dialogText.text = dialogs[currentline];
                    }
                }
            }
            else
            {
                juststarted = false;
            }
        }
    }

    public void showDialog(string[] lines,string speakername)
    {
        nameText.text = speakername;
        dialogs = lines;
        juststarted = true;
        currentline = 0;
        dialogText.text = dialogs[0];
        dialogBox.SetActive(true);
    }
}
