using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchTrap : MonoBehaviour {

private float a = 4f;

int timmer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y > -7.7f && timmer == 0){

	transform.Translate(Vector3.down * a* 4f * Time.deltaTime);

		}else{
			timmer ++;
			transform.Translate(Vector3.up * a* Time.deltaTime);
			if(timmer >= 170){
timmer = 0;
			}
		}
	}
}
