using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{



    //------------------------constantly changing to spawn player
    public Vector2 SpawningCoords;
    //-----------------------------------------

    //-----------------------inventory text

    Text Magictext;
    Text Combattext;
    Text Defensetext;
    Text Speedtext;
    //------------------------------

    //------------------------inventory variables

    public int magic;
    public int combat;
    public int defense;
    public int speed;
    //---------------------------------

    //-------------------------physical inventory slots


    //----------------------------inventory animators
    Animator InventoryAnimator;
    Animator StatsAnimator;
    //-----------------------------------










    //==============================================================================================================================================================

    //--------------------------------singleton pattern
    private void Awake()
    {
        int numofsesh = FindObjectsOfType<GameSession>().Length;
        if (numofsesh > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    //-----------------------------------------




    private void Update()
    {

    }

    //-------------------------------------------------------FUNCTIONs


    //-------------------------------------------------------





    //--------------------------------------------on every level loaded
    private void OnLevelWasLoaded()
    {

        InventoryAnimator = Inventory.instance.GetComponent<Animator>();
        StatsAnimator = GameObject.Find("Stats").GetComponent<Animator>();


    }
}