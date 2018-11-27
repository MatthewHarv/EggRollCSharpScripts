using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlayoff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
				if(GameMaster.startlevel){
gameObject.SetActive(false);
		}
	}
}
