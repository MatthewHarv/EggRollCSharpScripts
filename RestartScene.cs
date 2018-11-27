using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 GameMaster.spawnedallghosts=false;
		 GameMaster.resetEverything=true;
		SceneManager.LoadScene("MainLevel");   
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
