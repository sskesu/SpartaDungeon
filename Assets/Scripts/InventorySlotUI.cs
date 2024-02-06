using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    private ItemSlot curSlot;
    public int index; 
    public bool equipped; 

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        
    }

    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
    }

    public void OnClickButton()
    {
        Inventory.Instance.SelectItem(index);
    }
}
