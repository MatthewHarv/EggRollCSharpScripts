using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

public int a;

public bool learned = false;

void OnTriggerEnter2D(Collider2D other){

		//if(other.gameObject.CompareTag("Player")&& learned == false){
			//GameMaster.GM.loadTalk(a);
			//learned = true;
		//}
		if(other.gameObject.CompareTag("Player")){
			GameMaster.tutorialnumber = a;
		}


		if(a == 6){
		
		}
	}
}
