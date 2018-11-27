using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
Transform target;
 public float movementSpeed = 20.0f;
public Rigidbody2D rbcam;
	// Use this for initialization
	public bool keepFollow = true;
	
void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		//mycam = GetComponent<Camera> ();
		
	}

	// Update is called once per frame
	void Update () {
		if (target && keepFollow == true) {
		//+ new Vector3 (0, 0, -10)+shifter
		Vector3 camPosition = new Vector3(target.position.x + 12, 7.5f, -120 );
			transform.position = Vector3.Lerp (transform.position, camPosition, movementSpeed)+ new Vector3 (0, 0, -10);
		}else{
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}
 

}
