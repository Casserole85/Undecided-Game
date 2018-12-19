using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //-----------------------------is mouse holding
    public bool holding;
    //--------------------------------

    //----------------------------highlighting slots or not
    public int slotselectednumber = 0;
    //----------------------------------

    //-----------------------------sprite mouse is holding
    public Sprite itemholding;
    //----------------------------------

    //-----------------------------holding location of mouse
    private Vector3 mousePosition;
    //---------------------------------

    //-----------------------------how fast mouse object is 
    const float moveSpeed = 10f;
    //-----------------------------------

    //-----------------------------setting mouse object
    public GameObject mousefollow;
    //----------------------------------

    //-----------------------------linking game session to script
    GameSession gamesesh;
    //---------------------------------

    //-----------------------------setting player object
    Player player;
    //----------------------------------

    //--------------------------------mouse image
    [SerializeField] Sprite mousecurser;
    //----------------------------------

    //-----------------------------nothing image
   [SerializeField] Sprite empty;

    //-------------------------------






    [SerializeField] int Xtimes;
    [SerializeField] int Xadd;
    [SerializeField] int Ytimes;
    [SerializeField] int Yadd;


    private void Start()
    {
        itemholding = empty;
        holding = false;
        mousefollow = GameObject.Find("mousefollow");//------finding mouse object
        Debug.Log(mousefollow);
        mousefollow.GetComponent<Image>().sprite = mousecurser;//------mouse object sprite is curser
        gamesesh = FindObjectOfType<GameSession>();//------finding game session
        player = FindObjectOfType<Player>();//------finding player


    }


    void Update()
    {

        mouseupdate();
        ifholding();
        playerholding();
    }



    //----------------------------------------------------whatever slot is selected the sprite in that is in players hand
    void playerholding(){
       
        for (int i = 0; i < 20; i++)
        {
            var h = i + 1;
            if (slotselectednumber == h)
            {
                player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gamesesh.slots[i].transform.GetChild(1).GetComponent<Image>().sprite;
            }
        }
    }
    //--------------------------------------------------------------------------



    //-----------------------------------------------------updating mouse position
    void mouseupdate(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousefollow.transform.position = Vector2.Lerp(transform.position, correctingmousecoords(mousePosition), moveSpeed);
    }
    //---------------------------------------------------------------

    //-----------------------------------------------------sorting out mouse coords
    Vector3 correctingmousecoords(Vector3 coords)
    {
        var X = (coords.x * 103) + 765;
        var Y = (coords.y * 103) + 415;
        Vector3 newmouse = new Vector3(X, Y, coords.z);
        return newmouse;
    }
    //-------------------------------------------------------------

    //---------------------------------------------------------check if mouse is holding
    void ifholding(){
        if(mousefollow.GetComponent<Image>().sprite == null){
            mousefollow.GetComponent<Image>().sprite = mousecurser;
        }
        else if (mousefollow.GetComponent<Image>().sprite == mousecurser)
        {
            holding = false;
        }
        else
        {
            holding = true;
        }
    }
    //---------------------------------------------------------------


}




