using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public bool canActivate;
    public string[] lines;
    public string npcname;
    void Update()
    {
        if (canActivate && Input.GetButtonUp("Fire1") && !DialogBox.instance.dialogBox.activeInHierarchy)
        {
            DialogBox.instance.showDialog(lines,npcname);
        }
        if (!canActivate)
        {
            DialogBox.instance.dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canActivate = false;
        }
    }
}
