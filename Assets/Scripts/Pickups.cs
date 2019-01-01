using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public Item item;

    //------------------------------------------------when object touched player
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.name == "Player")
        {
            
            if (item.itemType() == "money")
            {
                Debug.Log("Picking up cash");
                Inventory.instance.addCoin(item.sellValue);//----adding coin value to money
                Destroy(gameObject);
                return;
            }

            Debug.Log("Picking up " + item.name);
            bool wasPickedUp = Inventory.instance.Add(item);
            
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
            
        }
    }
    //------------------------------------------------------------------

}
