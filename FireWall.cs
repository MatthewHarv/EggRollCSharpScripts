using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour {
    private float movementSpeed=2f;
private GameObject player;
private int scoretracker=0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameMaster.startlevel){
			 player = GameObject.FindGameObjectWithTag ("Player");

				  transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x,transform.position.y), movementSpeed * Time.deltaTime);
				  if(GameMaster.playerScore%100==0&&GameMaster.playerScore!=scoretracker){
					 
					  movementSpeed+=0.5f;
					  scoretracker=GameMaster.playerScore;
				  }
		}
	}

}
