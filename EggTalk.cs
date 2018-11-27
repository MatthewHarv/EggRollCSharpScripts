using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggTalk : MonoBehaviour {

public Text talk  = null; 

    	 string[] tutorial = {"This is a Check Point", "Lift click drag mouse to draw platform line",
		  "Watch out the dangerous fire","Egg damaged at high drops collisions", "Immue power up to avoid damage from enemy",
		  "Infinite line can help you to pass long gap","Draw a line to block drop items","It's time to runaway, here's Jonney!"};

	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowTalk(){


		GameMaster.ispaused=true;
			this.gameObject.SetActive(true);
			Time.timeScale=0f;
}

	 // Hide the egg talk
   public void Hide() {
	   GameMaster.ispaused=false;
      // Deactivate the panel
      gameObject.SetActive(false);
      // Resume the game (if paused)
      Time.timeScale = 1f;
   }

   public void setText(int x){
		talk.text = tutorial[x];
   }


}
