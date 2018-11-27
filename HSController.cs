using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;

public class HSController: MonoBehaviour {
  public string theID = "";
  public string theName = "";
  public int theScore = 0;
  private static HSController instance6;
  private Scene scene;
  private string secretKey = "582948372";
  string addScoreURL = "popcornchickenz.bplaced.net/addscore.php?";
  string highscoreURL = "popcornchickenz.bplaced.net/display.php";

  public string uniqueID;
  public string name3;
  int score;

  public string[] onlineHighscore;
  public Text texthere;
  public static HSController Instance {
    get {
      return instance6;
    }
  }

  void Awake() {
    if (instance6 == null)
      instance6 = this;
    else if (instance6 != this) {
      Destroy(gameObject);
      return;
    }

  }

  void Start() {
 scene = SceneManager.GetActiveScene();
 	if(scene.name=="MainLevel"){
        startGetScores();
     
   } else{
    theScore = GameMaster.playerScore;
    theName = GameMaster.playerName;
    theID = GameMaster.playeridhere;
    if (theScore > 0) {
      startPostScores();

      GameMaster.playerScore = 0;
      GameMaster.playerName = "";
      GameMaster.playeridhere = "";
      Invoke("startGetScores", 4);
    }

    startGetScores();
  }
  }

  public void startGetScores() {
    StartCoroutine(GetScores());
  }

  public void startPostScores() {
    StartCoroutine(PostScores());
  }

  public void updateOnlineHighscoreData() {
    uniqueID = theID;
    name3 = theName;
    score = theScore;
  }

  public string Md5Sum(string strToEncrypt) {
    System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
    byte[] bytes = ue.GetBytes(strToEncrypt);
    System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    byte[] hashBytes = md5.ComputeHash(bytes);

    string hashString = "";

    for (int i = 0; i < hashBytes.Length; i++) {
      hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
    }

    return hashString.PadLeft(32, '0');
  }

  IEnumerator PostScores() {
    updateOnlineHighscoreData();

    string hash = Md5Sum(name3 + score + secretKey);
    string post_url = addScoreURL + "uniqueID=" + uniqueID + "&name=" + WWW.EscapeURL(name3) + "&score=" + score + "&hash=" + hash;

    WWW hs_post = new WWW("http://" + post_url);
    yield
    return hs_post;

    if (hs_post.error != null) {
      print("There was an error posting the high score: " + hs_post.error);
    } else {
    }
  }

  IEnumerator GetScores() {
       if(scene.name!="MainLevel"){
    Scrolllist.Instance.loading = true;
       }
    using(UnityWebRequest www = UnityWebRequest.Get("http://" + highscoreURL)) {
      yield
      return www.SendWebRequest();

      if (www.isNetworkError || www.isHttpError) {
   
      } else {

        string help = www.downloadHandler.text;

        onlineHighscore = help.Split(";" [0]);
      }
      if(scene.name=="MainLevel"){

GameMaster.onlineHighscoreData=onlineHighscore;
        
      } else{
      Scrolllist.Instance.loading = false;
      Scrolllist.Instance.getScrollEntrys();
         texthere.text = "Database Loaded!";
    }
    }
    }

  }
