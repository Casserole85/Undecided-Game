using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  
    #region Singleton & Initialise

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory first!");
            return;
        }

        instance = this; //Singletons!
        
    }

    #endregion

    #region Money
    public float money = 0;

    public void addCoin(float amount)
    {
        money += amount;
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public float getCoin ()
    {
        return money;
    }

    #endregion

    #region Items

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Slot> items = new List<Slot>();
    public int space = 20;
    

    public bool Add (Item item)
    {
        //Check for existing item and stack if so
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                if (items[i].item.name == item.name)
                {
                    if (items[i].item.maxStack > items[i].stack)
                    {
                        items[i].stack++;
                        if (onItemChangedCallback != null)
                        {
                            onItemChangedCallback.Invoke();
                        }
                        return true;
                    }
                }
            }
        }

        //If not add to the list if there is space and break

        if (items.Count < space)
        {
            //Find first available space;
            //sorted list
            List<int> sorted = items.ConvertAll(i => i.inventoryPosition);
            sorted.Sort();
            int pos = 0;
            for (int i = 0; i< sorted.Count; i++)
            {
                if (sorted[i] == pos)
                {
                    pos++;
                }
            }
            items.Add(new Slot(item, pos));
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            return true;
        }

        //If no empty spaces then not enough space
        Debug.Log("Not enough space");
        return false; 
         
        
    }

    public bool AddToSlot(Item item, int pos)
    {
        if (items.Count < space)
        {
            items.Add(new Slot(item, pos));
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Remove(int pos)
    {
        Debug.Log("items = " + string.Join("",items.ConvertAll(i => i.item.name.ToString()).ToArray()));
        Slot slotToRemove = findItem(pos);
        items.Remove(slotToRemove);
        Debug.Log("items = " + string.Join("", items.ConvertAll(i => i.ToString()).ToArray()));
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public Slot findItem(int inventoryPos)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].inventoryPosition == inventoryPos)
            {
                return items[i];
            }
        }
        return null;
    }

    #endregion
}





