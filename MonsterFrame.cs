using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterFrame : MonoBehaviour {

public abstract float[] move_weight{
		get;
	}

public int state = 0;
//public GameObject target;

	// Use this for initialization
	void Start () {
	//	target = GameObject.FindGameObjectWithTag ("Player");
	}

	public abstract void stateSetUp();
	
	public void changeState(){
		float bid = Random.Range(0f, 1f);
		for(int i= 0; i< move_weight.Length; i++){
			bid -= move_weight [i];
			if(bid <= 0){
				state = i+1;
				return;
			}
		}
	}
	
	public abstract void excute_state();
	// Update is called once per frame
	void Update () {
		if(GameMaster.startlevel){
		if(state == 0)
		{
			changeState();
			stateSetUp();
		}
		excute_state();
	}}
}
