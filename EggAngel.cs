using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAngel : MonoBehaviour {

	public float speed = 4f;
 int timmer = 0;
// Vector3 position;
// Vector3 CurrentPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	// if(this.transform.position == CurrentPosition || timmer == 0){
		
	 	timmer ++ ;
	
	// 	float c = (float)timmer;
	// 	float b = c * 0.1;
	// 	float a = Mathf.Sin(timmer*0.1f)*2;
	


	// 	position = new Vector3 (transform.position.x+ a ,transform.position.y+timmer, transform.position.z); 
	// 	CurrentPosition = position;
		
	// //this.transform.position = new Vector3 (transform.position.x+ a ,transform.position.y, transform.position.z); 

	// }
	// this.transform.position = Vector2.MoveTowards (transform.position,position,speed*Time.deltaTime);
		
		this.transform.Translate(Vector3.up* speed*Time.deltaTime);
		if(timmer < 15){
	
			this.transform.Translate(Vector3.left* speed*Time.deltaTime);
			}else if (timmer > 15 && timmer < 30) {
		
this.transform.Translate(Vector3.right* speed*Time.deltaTime);
			} else if (timmer >30){
				timmer = 0;
			}
			
	}
}
