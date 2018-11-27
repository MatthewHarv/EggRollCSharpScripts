using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

// public bool isPaused;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	// 	if(Input.GetKeyDown(KeyCode.Escape)){
	// 		isPaused=!isPaused;
	// 	}
	}
	// public void Resume(){
	// 	isPaused=false;
	// }

public void ShowPaused(){
if(GameMaster.ispaused == true){
  GameMaster.ispaused=false;
      // Deactivate the panel
      gameObject.SetActive(false);
      // Resume the game (if paused)
    
      Time.timeScale = 1f;
}else{

		GameMaster.ispaused=true;
			gameObject.SetActive(true);
			Time.timeScale=0f;
		
}
}
	  // Hide the menu panel
   public void Hide() {
	   GameMaster.ispaused=false;
      // Deactivate the panel
      gameObject.SetActive(false);
      // Resume the game (if paused)
      Time.timeScale = 1f;
	
   }
   
public void NewGameBtn(string newGameLevel){
	GameMaster.spawnedallghosts=false;
GameMaster.resetEverything=true;
GameMaster.spawnedallghosts=false;
	SceneManager.LoadScene(newGameLevel);
	}
}
