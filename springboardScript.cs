using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springboardScript : MonoBehaviour {
public Rigidbody2D springbody;
public bool facingup=true;
private int waytospring=1;
	// Use this for initialization
	void Start () {
		if(facingup==false){
			waytospring=waytospring*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

void OnTriggerEnter2D(Collider2D other)
{
	if(other.gameObject.CompareTag("Player")){
	 Vector2 movement=new Vector2(0,waytospring);
				 springbody.AddForce(movement*100000f);
            FindObjectOfType<AudioManager>().Play("Boing");
				 startTimer();
		}  
	
	
		}

		void startTimer(){
Invoke("SpringTimerEnd",0.1f);
		}

		void SpringTimerEnd(){
			 Vector2 movement=new Vector2(0,-waytospring);
				 springbody.AddForce(movement*200000f);	
		}

	}

