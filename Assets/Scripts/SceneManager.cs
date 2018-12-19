using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    
    //-----------------------------loading scene function
	public void LoadScene(int index){
        Application.LoadLevel(index);
    }
    //--------------------------------------

    //-----------------------------Quit BUTTON
    public void Quitting(){
        Application.Quit();
    }
    //----------------------------------
}
