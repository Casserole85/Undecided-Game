using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    //---------------------------------what is object 
    [SerializeField] bool coin;
    [SerializeField] bool objects;
    [SerializeField] bool magic;
    //-------------------------------------

    //---------------------------------linking game session to script
    GameSession gameSession;
    //----------------------------------------

    //---------------------------------objects ability to be in inventory
    InventoryList inventoryList;
    //---------------------------------



    //==============================================================================================================================================================

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();//-----finding game session
    }


    //------------------------------------------------------------------------FUNCTIONS

    //------------------------------------------------when object touched
    private void OnTriggerEnter2D(Collider2D collision){
        if (coin){
            gameSession.coin += 1;//----adding coin value to money
            Destroy(gameObject);
        }

        if (objects)
        {
            inventoryList = new InventoryList(gameObject.GetComponent<SpriteRenderer>().sprite, gameObject.GetComponent<SpriteRenderer>().sprite.name, 1);//-----creating inventory item 
            gameSession.Additemtoinventory(inventoryList);//----adding this item to inventory's list
            gameSession.Applylistposition();//------apply list to slots
            Destroy(gameObject);
        }
    }
    //------------------------------------------------------------------

}
