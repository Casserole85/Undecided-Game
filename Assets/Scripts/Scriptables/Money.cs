using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Money")]


public class Money : Item
{
    public override string itemType()
    {
        return "money";
    }
}
