using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryCount;
    [SerializeField] private TextMeshProUGUI inventoryMax;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int maxSlots = 120;

    private void Start()
    {
        List<Item> inventory = GameManager.instance.Player.Inventory;
        inventoryCount.text = $"{inventory.Count}";
        inventoryMax.text = $"{maxSlots}";

        foreach (Item item in inventory)
        {
            MakeSlot(item);
        }

        int emptySlotsCount = maxSlots - inventory.Count;
        for (int i = 0; i < emptySlotsCount; i++)
        {
            MakeSlot();
        }
    }

    //새 슬롯 만들기
    private void MakeSlot(Item item = null)
    {
        GameObject newSlot = Instantiate(slotPrefab, content);
        UISlot uiSlot = newSlot.GetComponent<UISlot>();

        if (item != null)
        {
            uiSlot.Set(item);
            uiSlot.canvasGroup.interactable = true;
            uiSlot.button.onClick.AddListener(() => OnClickSlot(uiSlot));
        }
    }

    //아이템 클릭
    private void OnClickSlot(UISlot clickedSlot)
    {
        Item item = clickedSlot.item;
        item.isEquipped = !item.isEquipped;
        Character player = GameManager.instance.Player;

        if (item.isEquipped)
        {
            player.Equip(item);
        }
        else
        {
            player.UnEquip(item);
        }
        clickedSlot.Refresh();
    }
}
