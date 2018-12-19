using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slots : MonoBehaviour {

    //-----------------------------is slot holding
    bool holding;
    //--------------------------------

    //-----------------------------linking game session to script
    GameSession gamesesh;
    Inventory inventory;
    //---------------------------------

    //-------------------------------if this slot is selected
    bool slotselected;
    //------------------------------------------

    //--------------------------------sprites
    Sprite slotsprite;
    [SerializeField] Sprite EmptySprite;
    Sprite mousestoringsprite;
    //------------------------------------

    //---------------------------------slot number
    int slotnumber;
    Color slotcolour;
    //------------------------------------











    private void Start()
    {
        gamesesh = FindObjectOfType<GameSession>();//------finding game session
        inventory = FindObjectOfType<Inventory>();//--------finding inventory
        mousestoringsprite = inventory.itemholding;
        whichslotamI();
    }


    private void Update()
    {
    
        Isthisslotholding();
        hightlightingslot();

    }

    //--------------------------------------------------------------------------FUNCTIONs


    void hightlightingslot(){
        if(inventory.slotselectednumber == slotnumber){
            gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.red;
        }
        else{
            gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }


    //-----------------------------------------Is this slot holding something
    void Isthisslotholding(){
        if(slotsprite == null){
            slotsprite = EmptySprite;
        }
        else if (slotsprite == EmptySprite){
            holding = false;
        }
        else{
            holding = true;
        }
    }
    //-------------------------------------------------------

    //-----------------------------------------finding slot number
    void whichslotamI() {
        if (gameObject.name[8].ToString() == "0")
        {
            char numberinname = gameObject.name[9];
            var NAM = numberinname.ToString();
             slotnumber = int.Parse(NAM);
        }
        else
        {
            string NAM = gameObject.name[8].ToString() + gameObject.name[9].ToString();
            slotnumber = int.Parse(NAM);
        }
    }
    //--------------------------------------------------


                
    public void SLOTCLICKED()//---------when this slot it clicked as a BUTTON
    {
        if(inventory.slotselectednumber == slotnumber){
          
            inventory.mousefollow.transform.GetComponent<Image>().sprite = gameObject.transform.GetChild(1).GetComponent<Image>().sprite;
            gameObject.transform.GetChild(1).GetComponent<Image>().sprite = inventory.itemholding;
            inventory.itemholding = inventory.mousefollow.transform.GetComponent<Image>().sprite;
            inventory.slotselectednumber = 0;

        }
        else{
            inventory.slotselectednumber = slotnumber;
          
        }
    }
}
