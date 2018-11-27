using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 using System.Text.RegularExpressions;

public class SetHighscore : MonoBehaviour {


	public InputField namehere;
	public Text fText;
	public string fixinput;
public void get(string newGameLevel){
if(namehere.text.Length!=0){
int num=Random.Range(1,99999999);
GameMaster.playeridhere=num.ToString();
Regex rgx = new Regex("[^a-zA-Z0-9 -]");
fixinput = rgx.Replace(namehere.text, "");

GameMaster.playerName=fixinput;
SceneManager.LoadScene(newGameLevel);

}
}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
