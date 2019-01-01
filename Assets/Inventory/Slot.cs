using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    public Item item;
    public int stack = 1;
    public int inventoryPosition;

    public Slot(Item itemToInitialise, int pos)
    {
        item = itemToInitialise;
        inventoryPosition = pos;
    }

    public void IncreaseStack(int stackToAdd)
    {
        if (stackToAdd + stack <= item.maxStack)
        {
            stack += stackToAdd; 
        }
    }
}
