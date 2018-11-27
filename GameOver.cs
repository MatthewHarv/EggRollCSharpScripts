using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
public GameObject submitfieldhere;
 private Text ScoreUI;
  private Text RankUI;
public GameObject submitbuttonhere;
public int newscore=0;

void Start(){
    ScoreUI = GameObject.Find("ScoreUI").GetComponent < Text > ();
    RankUI = GameObject.Find("RankUI").GetComponent < Text > ();
    ScoreUI.text="Your Score is: "+GameMaster.playerScore;
    RankUI.text="Your Rank is: "+(GameMaster.rankingcounter+1);
}
   // Update is called once per frame
   void Update () {
     // if(Input.anyKey) {
       	if(Input.GetKeyDown(KeyCode.Escape)){
         // Go back to main menu
         resetterMain();
        
      }
      if(Input.GetKeyDown(KeyCode.Tab)){
resetterRestart();
      }
   }
private void resetterMain(){
  GameMaster.resetEverything=true;
       
         SceneManager.LoadScene("MainMenu");   
        
}
private void resetterRestart(){
 GameMaster.resetEverything=true;
       
         SceneManager.LoadScene("MainLevel");   
        
}
   // Display game over message

}
