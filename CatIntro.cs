using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIntro : MonoBehaviour {

private float movementSpeed=3f;
private GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
			 player = GameObject.FindGameObjectWithTag ("introegg");

				  transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x,transform.position.y), movementSpeed * Time.deltaTime);
		
	}

}
