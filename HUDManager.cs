using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

   // References to UI elements on the canvas
   public Text hudScore = null;
   public Slider hudHealth = null;

    int timmer = 0;
   // Health value currently displayed
   float health;

     // Reference to UI panel that is our pause menu
   public GameObject pauseMenuPanel;
   // Reference to panel's script object 
   PauseMenu pauseMenu;
   

  // public GameObject eggTalk;
//  private bool eggTalking = false;
// public GameObject eggTalkPanel;
// EggTalk eggTalk;
   public static HUDManager HUD;
   // Use this for initialization
   void Start () {


	 // Initialise the reference to the script object, which is a
      // component of the pause menu panel game object
      pauseMenu = pauseMenuPanel.GetComponent<PauseMenu>();
      pauseMenu.Hide();   

      // eggTalk = eggTalkPanel.GetComponent<EggTalk>();
      // eggTalk.Hide();
   }
   
   // Update is called once per frame
   void Update () {
      // Display the score
      //hudScore.text = "Score: " + scoreInfoProvider.score;
      
      // Display health - but rather than doing it in one go, change the value
      // gradually (over certain period of time)   
    //   health = Mathf.MoveTowards(health, healthInfoProvider.health, 20*Time.deltaTime);
    //   hudHealth.value = health;

	 if(Input.GetKey(KeyCode.Escape) && timmer <= 0) {
         // If user presses ESC, show the pause menu in pause mode
        	pauseMenu.ShowPaused();
			timmer = 20;
      }else if (timmer > 0){
			timmer --;
	  }



   }

 
// public void loadTalk(){

//   eggTalk.ShowTalk();
// }


}