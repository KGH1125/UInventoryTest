using UnityEngine;

public class Item
{
    public Sprite icon;
    public bool isEquipped = false; //장착여부
    public string itemName;
    public int itemAttack;
    public int itemDefense;
    public int itemHealth;
    public int itemCritical;

    public Item(Sprite icon, bool isEquipped, string itemName, int itemAttack, int itemDefense, int itemHealth, int itemCritical)
    {
        this.icon = icon;
        this.isEquipped = isEquipped;
        this.itemName = itemName;
        this.itemAttack = itemAttack;
        this.itemDefense = itemDefense;
        this.itemHealth = itemHealth;
        this.itemCritical = itemCritical;
    }

    public Item(int itemAttack, int itemDefense, int itemHealth, int itemCritical)
    {
        this.itemAttack = itemAttack;
        this.itemDefense = itemDefense;
        this.itemHealth = itemHealth;
        this.itemCritical = itemCritical;
    }
}
