using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using System.Linq;
public class GameMaster: MonoBehaviour {
 GameObject[] linetarget;
 public static int playerScore = 0;

 public static int tutorialnumber = 0;
 public static bool allowdraw = true;
 public static string playerName = "";
 public static float playerfatigue = 0;
 public static bool ispaused = false;
 public static string playeridhere = "";
 public static bool startlevel = false;
 public static float inklevelbar;
 public static string[] onlineHighscoreData;
 public GameObject deadEggHighscore;
 public Slider inksliderUI;
 public Slider healthsliderUI;
  public Slider powerupUI;
 private Text informationUI;
public static bool powerupTriggered=false;
    public Text score;
    public static int touchcounter=0;
 public Text rankscore;
 private Image backgroundinfo;

 private Image powerup1;
  private Image powerup2;
   private Image powerup3;
    private Image powerup4;

 public static bool showUI = false;

 public static float healthbar;
 public static bool inkpoweredup = false;
 GameObject player;
 public static int rankingcounter = 1;

public static bool eggisimmune=false;

public static bool spawnedallghosts=false;

 public GameObject[] deadAnimation;
 public static Boolean highscorePlottingfinished = false;
public static Vector3 TutorialSpawner=new Vector3(-2.1f,-1.29f,0);
 public static GameMaster GM;
 private Scene scene;
 private GameObject neweggo;
public static bool resetEverything=false;
public static int powerupcounter=0;
 public void Awake() {
  if (GM == null) {
   GM = this;
   DontDestroyOnLoad(gameObject);

  } else {
   Destroy(gameObject);

  }
 }

 void Start() {
  scene = SceneManager.GetActiveScene();

  if (scene.name == "MainLevel" || scene.name == "Kitchen") {
   //	onlineHighscoreData[1]="hello";
   player = GameObject.FindGameObjectWithTag("Player");

  }
 }

 void Update() {
     if(Input.touchCount>0&&touchcounter==0){
         startlevel=true;
     }
        if(resetEverything==true){
         allowdraw=true;
    playeridhere="";
    playerName="";
    playerScore=0;
    playerfatigue=0;
    spawnedallghosts=false;
    inklevelbar=1;
         resetEverything=false;
         powerupcounter=0;
         touchcounter=0;
     }
  scene = SceneManager.GetActiveScene();
  deadEggHighscore = GameObject.Find("eggwings");

  if (onlineHighscoreData != null) {
   if (scene.name == "MainLevel"&&spawnedallghosts==false) {
        int countman=1;
   
    for (int i = 0; i < onlineHighscoreData.Length - 1; i++) {

     if (i % 2 != 0) {

      neweggo= (GameObject) Instantiate(deadEggHighscore, new Vector3(Int32.Parse(onlineHighscoreData[i])-3, -3.2f, 0), Quaternion.identity);
      neweggo.name="deadegg"+countman;
      neweggo.GetComponentInChildren<TextMesh>().text=onlineHighscoreData[i-1];
      countman++;
      

     }
    } spawnedallghosts=true;
    }
   }
   
  



  if (scene.name == "MainLevel" || scene.name == "Kitchen") {
         powerupUI = GameObject.Find("PowerupCounter").GetComponent < Slider > ();
   powerup1=GameObject.Find("Powerup1").GetComponent < Image > ();
powerup2=GameObject.Find("Powerup2").GetComponent < Image > ();
powerup3=GameObject.Find("Powerup3").GetComponent < Image > ();
powerup4=GameObject.Find("Powerup4").GetComponent < Image > ();

if(powerupcounter==0){
      powerupUI.transform.localScale= new Vector3(0, 0, 0);
} else{
  powerupUI.transform.localScale= new Vector3(1, 1, 0);
}
if(powerupcounter==1){
    powerup1.enabled=true;
     powerup2.enabled=false;
      powerup3.enabled=false;
       powerup4.enabled=false;
}
if(powerupcounter==2){
    powerup1.enabled=true;
     powerup2.enabled=true;
      powerup3.enabled=false;
       powerup4.enabled=false;
}
if(powerupcounter==3){
    powerup1.enabled=true;
     powerup2.enabled=true;
      powerup3.enabled=true;
       powerup4.enabled=false;
}
if(powerupcounter==4){
    powerup1.enabled=true;
     powerup2.enabled=true;
      powerup3.enabled=true;
       powerup4.enabled=true;
}

      if(powerupTriggered&&powerupcounter<4){
          
          powerupcounter++;
          powerupTriggered=false;
   
      }

   
if(startlevel){
    if(Input.GetMouseButtonDown(1)&&powerupcounter>0&&eggisimmune==false){
          PoweredUpTimerStart();
                    FindObjectOfType<AudioManager>().Play("PowerUp");
                    powerupcounter--;
 
    }
}

   if (Input.GetKeyDown("space") && ispaused == false) {

    startlevel = true;
    showUI = true;
    linetarget = GameObject.FindGameObjectsWithTag("Line");
    foreach(GameObject linetargets in linetarget) {
     linetargets.SetActive(false);
    }

    if (player) {
     player.GetComponent < Rigidbody2D > ().constraints = RigidbodyConstraints2D.None;
    } else {
     player = GameObject.FindGameObjectWithTag("Player");

    }
   }

 

   informationUI = GameObject.Find("InfoText").GetComponent < Text > ();
   backgroundinfo = GameObject.Find("InfoBackground").GetComponent < Image > ();

   inksliderUI = GameObject.Find("InkSlider").GetComponent < Slider > ();
   inksliderUI.value = inklevelbar;

   healthsliderUI = GameObject.Find("HealthSlider").GetComponent < Slider > ();
   healthsliderUI.value = healthbar;

   if (scene.name == "MainLevel") {
    if (!GameMaster.startlevel) {
     informationUI.text = "Space to start, Esc to pause";

     backgroundinfo.enabled = true;
    } else {

     informationUI.text = "";
     backgroundinfo.enabled = false;

    }
   }
  }

  if (scene.name == "Kitchen") {
   if (!GameMaster.startlevel) {
    informationUI.text = "Space to start, Esc to pause";

    backgroundinfo.enabled = true;
   }


   if (tutorialnumber == 1) {
    informationUI.text = "Left Mouse button to draw, Space to erase lines";
    backgroundinfo.enabled = true;
   }

   if (tutorialnumber == 2) {
    informationUI.text = "Draw a line over the gap to save the egg";
    backgroundinfo.enabled = true;
   }
   if (tutorialnumber == 3) {
    informationUI.text = "Long Drops or harsh collisions will damage the egg";
    backgroundinfo.enabled = true;
   }

      if (tutorialnumber == 4) {
    informationUI.text = "Block the fire to save the egg";
    backgroundinfo.enabled = true;
   }

   if (tutorialnumber == 5) {
    informationUI.text = "Draw to block enemies attacks and movement";
    backgroundinfo.enabled = true;
   }
   if (tutorialnumber == 6) {
    informationUI.text = "Lightningbolt powerup = immunity and heals";
    backgroundinfo.enabled = true;
   }
   if (tutorialnumber == 7) {
    informationUI.text = "RightClick to use immune powerup";
    backgroundinfo.enabled = true;
   }
    if (tutorialnumber == 8) {
    informationUI.text = "Non-fire objects interact with lines, block the apple";
    backgroundinfo.enabled = true;
   }
   if (tutorialnumber == 9) {
    informationUI.text = "Block the spikes with a line";
    backgroundinfo.enabled = true;
   }
   if (tutorialnumber == 10) {
    informationUI.text = "Past eggs who have died, use highscore to join them!";
    backgroundinfo.enabled = true;
   }
   if (tutorialnumber == 11) {
    informationUI.text = "Watch out for the cat cook that will chase you!";
    backgroundinfo.enabled = true;
   }
      if (tutorialnumber == 12) {
    informationUI.text = "Black lines will reduce the eggs momentum";
    backgroundinfo.enabled = true;
   }
   
      if (tutorialnumber == 13) {
    informationUI.text = "Fire is not affected by lines";
    backgroundinfo.enabled = true;
   }


  }


  if (scene.name == "MainLevel") {




   score = GameObject.Find("ScoreText").GetComponent < Text > ();
   rankscore = GameObject.Find("RankText").GetComponent < Text > ();
   score.text = "Score :" + GameMaster.playerScore;
   if (onlineHighscoreData != null) {
    rankingcounter = (onlineHighscoreData.Length - 1) / 2;
    for (int i = 0; i < onlineHighscoreData.Length - 1; i++) {
     if (i % 2 != 0) {
      if (playerScore > Int32.Parse(onlineHighscoreData[i])) {
       rankingcounter--;
      }
     }
    }
    int truerank = rankingcounter + 1;
    if (truerank > 3) {
     rankscore.text = "Rank: " + (truerank) + "th";
    }
    if (truerank == 3) {
     rankscore.text = "Rank: " + (truerank) + "rd";
    }
    if (truerank == 2) {
     rankscore.text = "Rank: " + (truerank) + "nd";
    }
    if (truerank == 1) {
     rankscore.color = Color.red;
     score.color = Color.red;
     rankscore.text = "Rank: " + (truerank) + "st";
    }
   }
  }
 }
 
void PoweredUpTimerStart(){
	eggisimmune=true;
	if(playerfatigue>30){
		playerfatigue=playerfatigue-30;
	}
	else{
		playerfatigue=0;
	}
Invoke("PoweredUpTimerEnd",6f);
}

void PoweredUpTimerEnd(){
eggisimmune=false;
}


}