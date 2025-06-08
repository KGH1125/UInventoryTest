using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Item item;
    public Image iconImage;
    public GameObject equipDisplay;
    public Button button;
    public CanvasGroup canvasGroup;

    public void Set(Item newItem)
    {
        item = newItem;
        iconImage.sprite = item != null ? item.icon : null;
        Refresh();
    }

    //슬롯 새로고침
    public void Refresh()
    {
        equipDisplay.SetActive(item != null && item.isEquipped);
    }
}
