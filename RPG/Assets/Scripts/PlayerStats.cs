using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string charname;
    public int charlevel = 1;
    public int currentExp;
    public int[] addToExp;
    public int maxlevel = 100;
    public int currHP;
    public int baseExp = 1000;
    public int maxHP;
    public int currentMP;
    public int maxMP;
    public int strength;
    public int defence;
    public int wpnpwr;
    public int armorpwr;
    public string wpnname;
    public string armorname;
    public Sprite charImage;
    void Start()
    {
        addToExp = new int[maxlevel];
        addToExp[1] = baseExp;
        for(int i = 2; i < maxlevel; i++)
        {
            addToExp[i] = Mathf.FloorToInt(addToExp[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            addExp(500);
        }
    }

    void addExp(int exp)
    {
        if (charlevel < maxlevel)
        {
            currentExp += exp;
            if (currentExp >= addToExp[charlevel])
            {
                currentExp -= addToExp[charlevel];
                charlevel++;
            }
            if (charlevel % 2 == 0)
            {
                strength++;
            }
            else
            {
                defence++;
            }
        }
        else
        {
            currentExp = 0;
        }
    }
}
