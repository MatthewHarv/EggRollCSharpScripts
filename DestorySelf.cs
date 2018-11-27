using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour {

public float time ;
	// Use this for initialization
	void Start () {
		Invoke("deleteSelf",time);
	}
	
	// Destory
	void deleteSelf(){
Destroy(this.gameObject);
	}


}
