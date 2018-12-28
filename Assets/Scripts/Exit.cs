using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    //--------------------------------------------input level to be loaded by this exit
    [SerializeField] int LoadingLevel;
    //----------------------------------------------------

    //----------------------------------------------input place player is to be spawned 
    [SerializeField] Vector2 Spawningcoords;
    //----------------------------------------------------

    //-----------------------------------------------if exit is a door
    [SerializeField] bool door;
    //----------------------------------------------------

    //-------------------------------------------------if exit is within scene
    [SerializeField] bool inside;
    //----------------------------------------------------------

    //----------------------------------------------------linking game session to script
    GameSession gameSession;
    //-----------------------------------------------------------

    //---------------------------------------------------------exits animator
    Animator myanimator;
    //------------------------------------------------------------







    //==============================================================================================================================================================

	private void Start()
	{
        GameSession gameSession = FindObjectOfType<GameSession>();//-----finding game session

        if (door || inside){
            myanimator = GetComponent<Animator>();//-----finding animator if door

        }
	}


    //----------------------------------------------------when player touches it
	private void OnTriggerEnter2D(Collider2D collision){
        if (collision.name == "Player"){//-----checking its player
            if (door || inside){
                if (myanimator){
                    myanimator.SetBool("Touching", true);
                }
            }

            else{
                OpeningNextScene();
            }
        }
	}
    //----------------------------------------------------

    //----------------------------------------------------if player resting on exit can open door
	private void OnTriggerStay2D(Collider2D collision){
        if (door){
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (myanimator){
                    myanimator.SetBool("Opening", true);
                }
                if(door && !inside){
                    OpeningNextScene();
                }
              
            }
        }
	}
    //---------------------------------------------------------

    //----------------------------------------------------loading level + applying spawncoords
	public void OpeningNextScene(){
        GameSession gameSession = FindObjectOfType<GameSession>();//------finding game session
        gameSession.SpawningCoords = Spawningcoords;//-------giving game session to coords for player before exit no longer exists
        Application.LoadLevel(LoadingLevel);//-------loads the level selected
    }
    //------------------------------------------------------------

    //----------------------------------------------------if player not touching
	private void OnTriggerExit2D(Collider2D collision)
	{
        myanimator.SetBool("Touching", false);
        myanimator.SetBool("Opening", false);
	}
    //----------------------------------------------------
}
