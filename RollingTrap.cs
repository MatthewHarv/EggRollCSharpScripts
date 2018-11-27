using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingTrap : MonoBehaviour {

public float speed = 5f;
public bool twitch = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(twitch == false)
		{
			this.transform.Rotate(Vector3.back,45*Time.deltaTime * speed);
			
		}else{this.transform.Rotate(Vector3.forward,45*Time.deltaTime * speed);
}
		
	}
void OnCollisionEnter2D(Collision2D other){
if(other.gameObject.CompareTag("Line")){
		if(twitch){
twitch = false;
		}else{
twitch = true;
		}
		}  
}

}
