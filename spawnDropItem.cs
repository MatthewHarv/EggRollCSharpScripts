using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDropItem : MonoBehaviour {

//public GameObject[] DropedItem;

public GameObject DropedItem;

	// Use this for initialization
	void Start () {
		InvokeRepeating("spawnThis", 2.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnThis(){
		float a = Random.Range(-1f,1f);
		Vector3 point = new Vector3(transform.position.x+a, transform.position.y,transform.position.z);
		Instantiate(DropedItem, point, Quaternion.identity);
	}
}
