using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapTrigger : MonoBehaviour {


public Rigidbody2D rbFireWall;
    public float movementSpeed;
	bool playerarrived=false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		
		if(playerarrived){
		     Vector2 movement=new Vector2(0,1);
				 rbFireWall.AddForce(movement*movementSpeed);	
		}
	}
	void OnTriggerEnter2D(Collider2D other)
{
	if(other.gameObject.CompareTag("Player")){
	playerarrived=true;
		}  
	}
	


}
