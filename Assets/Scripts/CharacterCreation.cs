using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour {


    //-------------------------------------finding player object
    [SerializeField] GameObject playerprefab;
    //-------------------------------------

    //-------------------------------spawn probability
    float Spawnchance;
    //-----------------------------------

    //---------------------------------scene starting changing variable
    int StartingScene;
    //------------------------------------------

    //----------------------------------place for begining scene
    Vector2 Startingcoords;
    //-------------------------------------

    //----------------------------------linking to scenemanger script
    SceneManager sceneManager;
    //-----------------------------------------






    //==============================================================================================================================================================
   
    //-------------------------------------finding  scene manger
    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }
    //-------------------------------------------



    //-------------------------------------deciding which spawn point for player from BUTTON
	public void SpawningCharacter(){ 
        
        Spawnchance = Random.Range(0.0f, 10.0f);

        //-------------------------------------Castle
        if (Spawnchance >= 0.9f)
        {
            StartingScene = 1;
            Startingcoords = new Vector2(8, 5);
            CharacterPoz();
        }

        //---------------------------------Village
        else if (Spawnchance >= 0.4f && Spawnchance < 0.9f)
        {
            StartingScene = 39;
            Startingcoords = new Vector2(0, 0);
            CharacterPoz();
        }

        //-------------------------------------Wild
        else if (Spawnchance < 0.4f)
        {
            StartingScene = 42;
            Startingcoords = new Vector2(0, 0);
            CharacterPoz();
        }
    }
    //--------------------------------------------------------


    //-------------------------------------------------------------------------------------FUNCTIONs

    //-------------------------------------loading the scene decided
    private void CharacterPoz(){
        sceneManager.LoadScene(StartingScene);
    }
    //--------------------------------------------

    //-----------------------------------------on level loaded for the first time
	private void OnLevelWasLoaded(int level)
	{
        Player player = FindObjectOfType<Player>();
        player.transform.position = Startingcoords;
	}
    //-------------------------------------------------------




}
