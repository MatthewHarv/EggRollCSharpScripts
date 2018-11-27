using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayer : MonoBehaviour {
public Rigidbody2D rb;
public bool rolltime=false;
public bool startintrotime=false;
public int jumpamount=1;

	
	// Update is called once per frame
	void Update () {
		Vector2 movement=new Vector2(1,0);
				rb.AddForce(movement*2);
	
	if(startintrotime==false&&jumpamount>0){
		Invoke("startIntro", 1.5f);
		startintrotime=true;
	}
	}



void startIntro(){
	if(jumpamount>0){
	Vector2 movement=new Vector2(0,1);
				rb.AddForce(movement*200);
					 movement=new Vector2(1,0);
				rb.AddForce(movement*4);
				jumpamount--;
				startintrotime=false;
}
}
}
