using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	
// 	void OnCollisionEnter2D(Collision2D other){
// 		if(other.gameObject.CompareTag("Player")){
// 		
// GameMaster.GM.reborn = other.transform.position;
// 		}

// }  
	


void OnTriggerEnter2D(Collider2D other){

		//checkPoint
		if(other.gameObject.CompareTag("Player")){
			GameMaster.TutorialSpawner = other.transform.position;
		
			
		}
	}
}
