
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]

public class Food : Item
{
    public float healthRegen;
    public float attackBuff;
    public float defenceBuff;
    public string statusEffect;

    public override string itemType()
    {
        return "consumable";
    }
}
