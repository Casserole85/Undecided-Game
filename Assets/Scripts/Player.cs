using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    //--------------------------------------player physics
    Rigidbody2D myrigidbody;
    //---------------------------------------------

    //--------------------------------------player animator
    Animator myanimator;
    //--------------------------------------------

    //--------------------------------------player collider
    Collider2D mycollider;
    //--------------------------------------------

    //--------------------------------------linking to game session script
    GameSession Gamesesh;
    //--------------------------------------------------

    //----------------------------------------setting player control stats
    [SerializeField] float runsped = 5f;
    [SerializeField] float runspedflat = 5f;
    [SerializeField] float jumpspeed = 5f;
    //----------------------------------------------------

    //------------------------------------------deciding type of player controller
    [SerializeField] bool ControlFlat;
    //--------------------------------------------------------
	




    //==============================================================================================================================================================

	void Start()
    {
        Gamesesh = FindObjectOfType<GameSession>();//-------finding game session
        myrigidbody = GetComponent<Rigidbody2D>();//-------finding player physics
        myanimator = GetComponent<Animator>();//---------finding player animator
        mycollider = GetComponent<Collider2D>();//---------finding player collider


        transform.position = Gamesesh.SpawningCoords;//---------every time player created apply spawning coords
        


        decidingtypeofcontroller();//---------------if TOPDOWN present set player controller
    }


    void Update()
    {
        Walk();//-----side on walk mechanic
        WALK();//-----topdown walk mechanic
        Flip();//-----side on flipping character
        Jump();//-----side on jumping mechanic
    }



    //---------------------------------------------------------------------FUNCTIONS


    //-----------------------------deciding type of controller
    void decidingtypeofcontroller(){
        if (GameObject.Find("TopDown"))
        {
            ControlFlat = true;
            myrigidbody.gravityScale = 0;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            ControlFlat = false;
            myrigidbody.gravityScale = 5;
            transform.localScale = new Vector2(1, 1);
        }
    }
    //--------------------------------------------




    //--------------------------------------------side on walking
    private void Walk()
    {
        if (!ControlFlat){
            float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //-----value between -1 and + 1 input
            Vector2 playervel = new Vector2(controlThrow * runsped, myrigidbody.velocity.y);//-----player velocity is speed X -1 and + 1 value
            myrigidbody.velocity = playervel;//-----applying velocity

            if (myrigidbody.velocity.x != 0f)//------if player is moving
            {
                //myanimator.SetBool("Walking", true);      yet to make animation
            }
            else
            {
                //myanimator.SetBool("Walking", false);    yet to make animation
            }
        }
    }
    //----------------------------------------------------


    //--------------------------------------------topdown walking
    private void WALK(){
        if (ControlFlat)
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");//-------- -1 and +1 input
            float Controlthrow = CrossPlatformInputManager.GetAxis("Vertical");//------- -1 and +1 input
            transform.position += new Vector3(controlThrow * runspedflat, Controlthrow * runspedflat, 0);//---------adding the velocity (speed X value) to player movement
            bool playerismovinghor = controlThrow != 0;//------player is moving horizontally if true, not used

            //-----------setting player animator 
            if (Controlthrow > 0  ){
                myanimator.SetBool("WalkingBackwards", true);
            }
            else{
                myanimator.SetBool("WalkingBackwards", false);
            }

            if(Controlthrow < 0){
                myanimator.SetBool("WalkingForwards", true);
            }
            else{
                myanimator.SetBool("WalkingForwards", false);
            }
            //----------------------
        }
    }
    //----------------------------------------------------


    //--------------------------------------------side on jumping mechanic
    private void Jump()
    {
        if (!(ControlFlat)){
            if (!mycollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))//-----if player touching ground you can jump
            {
                return;
            }

            if (CrossPlatformInputManager.GetButtonDown("Jump"))//-----if button pressed to jump
            {
                Vector2 Jumpvelocitytoadd = new Vector2(0f, jumpspeed);//----setting velocity as jump speed
                myrigidbody.velocity += Jumpvelocitytoadd;//-------adding velocity to player 
                //myanimator.SetBool("Jumping", true);   yet to make animation
            }
            else
            {
                //myanimator.SetBool("Jumping", false);    yet to make animation
            }
        }
    }
    //----------------------------------------------------



    //--------------------------------------------side on flipping mechanic
    private void Flip()
    {
        if (!ControlFlat){
            bool playerhashorizontalsped = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon; // if x velocity is bigger tham 0 ie positive

            if (playerhashorizontalsped)
            {
                transform.localScale = new Vector2(Mathf.Sign(myrigidbody.velocity.x) * 1, 1); // sign gives 1 if posiive and - 1 if negative, and setting player scale as that
            }
        }
    }
    //--------------------------------------------

}