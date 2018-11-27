using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdTest : MonsterFrame {
	public float[] Move_Weight = new float[3];
	public  override float[] move_weight{
		get{ return Move_Weight;}
	}

	System.Action move;
	int timmer = 0;
	GameObject target;
	Vector3 position;
	Vector2 direction = new Vector2(0,0);

	public float speed = 8f;
	public GameObject bullet;//shoot perfab

//	private float Distance = 1f;
	//private float xDistance;


	public float range;


	void Start(){
	
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	public override void excute_state(){

		if(position.x < 0){
			transform.localRotation = Quaternion.Euler (0,180,0);
		}else{
			transform.localRotation = Quaternion.Euler (0,0,0);
		}
		
		if(target){
		float Distance = Vector2.Distance(transform.position,target.transform.position);
if(Distance < range){
		move();
		}
		}else{
target = GameObject.FindGameObjectWithTag ("Player");
		}
	}

	public override void stateSetUp(){

		
		switch (state) {
		case 1: 
			timmer = 20;
			position = new Vector3 (Random.Range (-3f, 3f), Random.Range (-2f, 2f), 0).normalized;
			move = randomWalk;
			break;
		case 2:
			timmer = 30;
			direction = target.transform.position - transform.position;
			move = bullet8;
			break;
		case 3:
			timmer = 0;
			direction = target.transform.position - transform.position;
			position = new Vector2 (target.transform.position.x, target.transform.position.y);
			move = dash;
			break;
		}
	
	
	}
	void randomWalk(){
		timmer--;
		if(timmer <= 0){
			state = 0;
			return;
		}
			//Bug Animation
		AnimeFace (position);
		transform.position = Vector2.MoveTowards (transform.position, transform.position + position, speed* Time.deltaTime);
	}

	void bullet8(){
		timmer--;
		if (timmer % 3 != 0)
			return;
		if(timmer <= 0){
			state = -1;
			move = rest;
			return;
		}
		float angle = Mathf.Atan2 (direction.y, direction.x)* Mathf.Rad2Deg;
		angle += 10 *(((timmer/3)%5)-2);
		Quaternion rotate = Quaternion.AngleAxis (angle, Vector3.forward);
		GameObject shootPoint = this.gameObject.transform.GetChild (0).gameObject;
		Instantiate (bullet, shootPoint.transform.position, rotate);

	}

	void dash(){
		float dist = Vector3.Distance (position, transform.position);
		if (dist < 1) {
			timmer++;
			if (timmer >= 10) {
				state = -1;
				move = rest;
				return;
			}
		} else {
			transform.position = Vector2.MoveTowards (transform.position,position,2*speed*Time.deltaTime);
			//Bug Animation
			Vector3 ToPosition = position - transform.position;
		
			  AnimeFace(ToPosition);
			return;
		}
	}

	void rest(){
		timmer++;
		if(timmer >= 30){
			state = 0;
			return;
		}
	}
	//Bug Animation  need to be fixed
	public void AnimeFace(Vector3 position){
		//xDistance = transform.position.x - position.x;

		if(position.x < 0){
			this.GetComponent<SpriteRenderer>().flipX = true;
		}else{
			this.GetComponent<SpriteRenderer>().flipX = false;	
		}
	}


}
