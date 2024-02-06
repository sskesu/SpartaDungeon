using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    private ItemSlot curSlot;
    public int index;
    public GameObject isEquip;

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        if (slot.item.equipped)
            isEquip.SetActive(true);
        else
            isEquip.SetActive(false);
    }

    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
    }

    public void OnClickButton()
    {
        if (curSlot != null)
        {
            Inventory.Instance.SelectItem(index);
        }
    }
}
