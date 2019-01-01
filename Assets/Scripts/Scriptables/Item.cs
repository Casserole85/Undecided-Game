
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public string desc;
    public Sprite icon = null;
    public int maxStack;
    public float buyValue;
    public float sellValue;

    public virtual string itemType()
    {
        return null; 
    }
}
