using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class PhoenixScript : MonoBehaviour { 

	//public Transform target;
	public float speed = 5f;
 	private float Distance = 1f;
	 private float xDistance;
	private float range= 35;
	private int timmer=60;
Vector2 direction = new Vector2(0,0);
	public GameObject bullet;
	private bool hasshot=false;

private GameObject player;
    //Switch of monster .

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

 void Update ()
     {


        if (GameMaster.startlevel){
   player = GameObject.FindGameObjectWithTag ("Player");
   direction = player.transform.position - transform.position;
         
			Distance = Vector2.Distance(transform.position, player.transform.position);
		    xDistance = transform.position.x - player.transform.position.x;
			animator.SetFloat ("input_x", direction.x);
				 

		if (player) {
			if (player.GetComponent<Player> ().dead == false) {
			
		

				if (range > Distance && Distance > 10) {
					transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
					animator.SetBool ("Move", true);
				} else if (Distance < 10) {
					animator.SetBool ("Attack", true);
					shootFire ();
					transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * 0.7f * Time.deltaTime);
					//  hasshot =true;
					animator.SetBool ("Attack", false);
				}

			} else {
				animator.SetBool ("Move", false);
				animator.SetBool ("Attack", false);
			}
		} else {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
	//	 if(hasshot){
		//	 transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
         //   }
     
	 }
	 }
    

void shootFire(){
		timmer--;
		if (timmer <= 0) {
			timmer = 60;
			return;
		}
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		angle += 10 * (((timmer / 3) % 5) - 2);
		Quaternion rotate = Quaternion.AngleAxis (angle, Vector3.forward);
		GameObject shootPoint = this.gameObject.transform.GetChild (0).gameObject;
		Instantiate (bullet, shootPoint.transform.position, rotate);
        
	}
}



