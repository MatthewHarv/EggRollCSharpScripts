using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour {

public Rigidbody2D[] spikebody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
{
	if(other.gameObject.CompareTag("Player")){
	

		foreach (Rigidbody2D spikebodies in spikebody)
				 spikebodies.gravityScale=1.5f;	
			
		}  
	
	
		}
}
