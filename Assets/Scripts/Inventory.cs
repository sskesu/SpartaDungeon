using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot
{
    public ItemData item;
}

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public InventorySlotUI[] inventorySlots;
    public ItemSlot[] slots;

    private Player player;

    private void Awake()
    {
        Instance = this;
        player = GetComponent<Player>();
    }

    private void Start()
    {
        slots = new ItemSlot[inventorySlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            inventorySlots[i].index = i;
            inventorySlots[i].Clear();
        }
    }

    public void SelectItem(int index)
    {
        if (slots[index] == null)
            return;
        //��� �˾�
        UIManager.instance.OpenEquipPopup(slots[index].item);
    }

    public void AddItem(ItemData item)
    {
        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = item;
            UpdateUI();
            UIManager.instance.UpdateUI();
        }
    }

    public ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }

        return null;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                inventorySlots[i].Set(slots[i]);
            }
            else
            {
                inventorySlots[i].Clear();
            }
        }
    }
}
