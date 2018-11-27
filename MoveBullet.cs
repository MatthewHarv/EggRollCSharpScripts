using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {
	public int bulletSpeed;
	public float timeToDestory;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * bulletSpeed);
		Destroy (this.gameObject, timeToDestory);
	}


	void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Player"){
			Destroy (this.gameObject);
		}
	}
}
