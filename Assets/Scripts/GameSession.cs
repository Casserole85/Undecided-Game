using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {



    //------------------------constantly changing to spawn player
    public Vector2 SpawningCoords;
    //-----------------------------------------

    //-----------------------inventory text
    TMP_Text Cointext;
    Text Magictext;
    Text Combattext;
    Text Defensetext;
    Text Speedtext;
    //------------------------------

    //------------------------inventory variables
    public int coin;
    public int magic;
    public int combat;
    public int defense;
    public int speed;
    public const int numofslots = 20;
    bool inventoryopen = false;
    Inventory inventory;
    //---------------------------------

    //-------------------------physical inventory slots
    GameObject Inventory;
    public List<GameObject> slots = new List<GameObject>(new GameObject[numofslots]);
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public GameObject slot8;
    public GameObject slot9;
    public GameObject slot10;
    public GameObject slot11;
    public GameObject slot12;
    public GameObject slot13;
    public GameObject slot14;
    public GameObject slot15;
    public GameObject slot16;
    public GameObject slot17;
    public GameObject slot18;
    public GameObject slot19;
    public GameObject slot20;
    //-------------------------------------

    //----------------------------inventory animators
    Animator InventoryAnimator;
    Animator StatsAnimator;
    //-----------------------------------

    //------------------------------------inventory item list and physical game objects
    public List<InventoryList> inventoryListies = new List<InventoryList>(new InventoryList[numofslots]);

    //-----------------------------------------

    //-----------------------------------empty sprite for inventory
    [SerializeField] Sprite empty;
    //---------------------------------------------










    //==============================================================================================================================================================

    //--------------------------------singleton pattern
    private void Awake()
    {
        int numofsesh = FindObjectsOfType<GameSession>().Length;
        if (numofsesh > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }

        Fillinglist();
    }
    //-----------------------------------------




    private void Update()
    {
        applymoneytext();
        openinginventory();
    }

    //-------------------------------------------------------FUNCTIONs

    //-------------------------------------------applying items in slots to list
    public void Applyitemposition(){
       

        for (int i = 0; i < numofslots; i++)
        {
            InventoryList item1 = new InventoryList(slots[i].transform.GetChild(1).GetComponent<Image>().sprite, slots[i].transform.GetChild(1).GetComponent<Image>().sprite.name, 1);
            inventoryListies[i] = item1;
        }

    }
    //-------------------------------------------------------


    //-------------------------------------------applying list to items in slots
    public void Applylistposition()
    {
        //slot1.transform.GetChild(1).GetComponent<Image>().sprite = inventoryListies[0].item;
        for (int i = 0; i < numofslots; i++)
        {
            slots[i].transform.GetChild(1).GetComponent<Image>().sprite = inventoryListies[i].item;
        }

    }
    //-------------------------------------------------------



    //--------------------------------------------on every level loaded
    private void OnLevelWasLoaded()
    {
        GameObject Inventory = GameObject.Find("Main Inventory");//------finding inventory
        InventoryAnimator = Inventory.GetComponent<Animator>();

        Cointext = GameObject.Find("coin text").GetComponent<TMP_Text>();//------finding inventory text
        StatsAnimator = GameObject.Find("Stats").GetComponent<Animator>();

        inventory = FindObjectOfType<Inventory>();


        for (int i = 0; i < numofslots; i++)
        {
                slots[i] = GameObject.Find("ItemSlot" + (i + 1).ToString("00"));
            Debug.Log("ItemSlot" + (i+ 1).ToString("00"));
        }
        Applylistposition();
        Seeinventorylist();

    }
    //-------------------------------------------------

    //---------------------------------------See inventory list
    public void Seeinventorylist()
    {
        Debug.Log("----------------------------------------");
        for(int i = 0; i < numofslots; i++)
        {
            Debug.Log(inventoryListies[i].item.name);
        }
    }
    //--------------------------------------------   

    //-----------------------------opening inventory
    private void openinginventory(){
        if (Input.GetKeyDown(KeyCode.I) && inventoryopen == false)
        {
            showinventory();

            Seeinventorylist();
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventoryopen == true)
        {
            Applyitemposition();
            closeInventory();
        }
    }
    //-------------------------------------

    //-------------------------------clearing all inventory
    private void clearinventoryslots()
    {


        for (int i = 0; i < numofslots; i++)
        {
            inventoryListies[i] = null;
        }
    }
    //---------------------------------------

   


    //-----------------------------adding to inventory
    public void Additemtoinventory(InventoryList Item){
       
        for (int i = 0; i < numofslots; i++ ){

            if (inventoryListies[i] == null || inventoryListies[i].name == empty.name){
                inventoryListies.Insert(i, Item);
                Debug.LogError("Inserting Item into the list");
                return;
            }
            else if (inventoryListies[i] == Item)
            {

            }
        }
    }
    //------------------------------------

    //-----------------------------------filling list with empty at begining
    public void Fillinglist()
    {
        InventoryList emptyobject = new InventoryList(empty, empty.name, 0);
        //inventoryListies.Insert(0, emptyobject);
        for (int i = 0; i < numofslots; i++)
        {
            inventoryListies.Insert(i, emptyobject);
        }

    }




    //-----------------------------------------------

    

    //------------------------------------------hiding and showing inventory
    private void showinventory()
    {
        InventoryAnimator.SetBool("InventoryOpen", true);
        StatsAnimator.SetBool("InventoryOpen", true);
        inventoryopen = true;
        //slot1.SetActive(true);
        for (int i = 0; i < numofslots; i++)
        {
            slots[i].SetActive(true);
        }
    }

    private void closeInventory()
    {
        InventoryAnimator.SetBool("InventoryOpen", false);
        StatsAnimator.SetBool("InventoryOpen", false);
        inventoryopen = false;
        for (int i = 0; i < numofslots; i++)
        {
            slots[i].SetActive(false);
        }
        inventory.slotselectednumber = 0;
    }
    //---------------------------------------------------------

    //---------------------------updating money text
    private void applymoneytext()
    {
        int zeronum = 5 - coin.ToString().Length;
        string coins = new string('0', zeronum) + coin.ToString();
        if (Cointext == null){
            return;
        }
        Cointext.text = coins;
    }
    //-------------------------------------
   
    }


