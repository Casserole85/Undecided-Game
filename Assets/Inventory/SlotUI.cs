
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public Image stacker;
    public Image buttonImage;
    public TMP_Text stackText;

    Color activeColor = new Color(1, 0.51f, 0);
    Color normalColor = new Color(1, 1, 1);

    InventoryUI inventoryUI;

    public Item item = null;

    private void Start()
    {
        inventoryUI = GetComponentInParent<InventoryUI>();
    }

    public void updateItem(Item itemToAdd)
    {
        item = itemToAdd;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void removeItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        stacker.enabled = false;
        stackText.enabled = false;
        changeColor(false);
    }

    public void modifyStack(int stack)
    {
        if (stack == 1)
        {
            stacker.enabled = false;
            stackText.enabled = false;
            return;
        }

        if (stack >= 2)
        {
            stacker.enabled = true;
            stackText.enabled = true;
            stackText.text = "x" + stack;
            stackText.fontSize = 8;
        }
        if (stack >= 10)
        {
            stackText.fontSize = 6;
        }
    }

    public void changeColor(bool selected)
    {
        if (selected)
        {
            buttonImage.color = activeColor;
        }
        else
        {
            buttonImage.color = normalColor;
        }
    }

    public void onButtonSelect()
    {
        inventoryUI.selectItem(this);
    }
}
