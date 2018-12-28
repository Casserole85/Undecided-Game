using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryList : IComparable<InventoryList> {

    //----------------each item stores this
    public Sprite item;
    public String name;
    public int stacking;
    //-----------------------------





    //-----------------------------irrelivent bullshit that I dont understand


    public InventoryList(Sprite newsprite, String newname, int newstacking){
        item = newsprite;
        name = newname;
        stacking = newstacking;
    }


    public int CompareTo(InventoryList inventoryList){
        if (inventoryList == null){
            return 1;
        }

        return 0;
    }
}
