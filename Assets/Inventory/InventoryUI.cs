using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public TMP_Text moneyText;
    public GameObject dropButton;
    public GameObject inventoryUI;

    SlotUI[] slots;
    List<Slot> items;

    SlotUI selectedSlot;
    

    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        items = Inventory.instance.items;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<SlotUI>();
        dropButton.SetActive(false);
        inventoryUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < items.Count; i++ )
        {
            int pos = items[i].inventoryPosition;
            slots[pos].updateItem(items[i].item);
            slots[pos].modifyStack(items[i].stack);
        }

        float coin = Inventory.instance.getCoin();
        moneyText.text = "Money : " + coin.ToString("000000");
    }

    public void selectItem(SlotUI slot)
    {
        if (selectedSlot == slot)
        {
            slot.changeColor(false);
            selectedSlot = null;

            dropButton.SetActive(false);
            return;
        }

        //if (slot.item == null)
        //{
        //    int pos = System.Array.IndexOf(slots, slot);
        //    moveItem(selectedSlot, pos);
        //}

        selectedSlot.changeColor(false);
        selectedSlot = slot;
        
        selectedSlot.changeColor(true);
        dropButton.SetActive(true);
    }

    public void removeItem()
    {
        if (selectedSlot == null)
        {
            return;
        }

        int pos = System.Array.IndexOf(slots, selectedSlot);
        slots[pos].removeItem();
        Inventory.instance.Remove(pos);
        selectedSlot = null;
        dropButton.SetActive(false);
    }

    //public void moveItem(SlotUI slot, int pos)
    //{
    //    int positionOfSlot = System.Array.IndexOf(slots, slot);
    //    Slot slotToModify = Inventory.instance.findItem(positionOfSlot);
    //    slotToModify.inventoryPosition = pos;
    //}
}
