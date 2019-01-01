
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]

public class Weapon : Item
{
    public float damage;
    public float durability;
    public float levelReq;
    public int ranking;

    public override string itemType()
    {
        return "weapon";
    }
}
