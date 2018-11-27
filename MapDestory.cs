using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapDestory : MonoBehaviour {
GameObject targetP;
private Scene scene;
	// Use this for initialization
	void Start () {
		targetP = GameObject.FindGameObjectWithTag ("Player");
		 scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		if(scene.name == "MainLevel"){
		if (targetP) {
		if((targetP.transform.position.x - transform.position.x) >= 64 ){
			Destroy(this.gameObject);
		}
	
		}else{
			targetP = GameObject.FindGameObjectWithTag ("Player");
		}

	}
}
}
