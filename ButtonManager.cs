using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
  
    public GameObject onlinehighscorebutton;
    public GameObject newgamebutton;
    public GameObject quitbutton;
     public GameObject kitchenbutton;
    public GameObject mainlevelbutton;
     public GameObject backbutton;
public void NewGameBtn(string newGameLevel){
	/* 
    GameMaster.playerHealth=3;
    GameMaster.playeridhere="";
    GameMaster.playerName="";
    GameMaster.playerScore=0;
    GameMaster.multiplier=1;
    GameMaster.hitbyalien=false;
    */
    GameMaster.spawnedallghosts=false;
      if (newGameLevel=="LevelSelect") {
    
             onlinehighscorebutton = GameObject.Find("Highscores");
             newgamebutton = GameObject.Find("NewGameBtn");
             quitbutton = GameObject.Find("Quit");
           kitchenbutton=GameObject.Find("KitchenButton");
              mainlevelbutton=GameObject.Find("MainLevelButton");
              backbutton=GameObject.Find("Backbutton");
             
     onlinehighscorebutton.SetActive(false);
     newgamebutton.SetActive(false);
     quitbutton.SetActive(false);
  kitchenbutton.transform.localScale= new Vector3(1, 1, 0);
    mainlevelbutton.transform.localScale= new Vector3(1, 1, 0);
    backbutton.transform.localScale= new Vector3(1, 1, 0);
      }
      
      else if(newGameLevel=="back"){
           onlinehighscorebutton.SetActive(true);
     newgamebutton.SetActive(true);
     quitbutton.SetActive(true);
       kitchenbutton.transform.localScale= new Vector3(0, 0, 0);
    mainlevelbutton.transform.localScale= new Vector3(0, 0, 0);
    backbutton.transform.localScale= new Vector3(0, 0, 0);

      } else{
SceneManager.LoadScene(newGameLevel);
      }
}
public void ExitGameBtn(){
Application.Quit();
}

}

