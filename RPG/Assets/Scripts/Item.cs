using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isarmor;
    public bool isItem;
    public bool isWeapon;

    [Header("Item Details")]
    public string itemName;
    public string Description;
    public int Itemvalue;
    public Sprite itemImage;

    [Header("Item value")]
    public int amountToChange;
    public bool affectHp;
    public bool affectMp;
    public bool affectStr;

    [Header("Weapon/Armor Detials")]
    public int weaponStrength;
    public int armorStrength;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
