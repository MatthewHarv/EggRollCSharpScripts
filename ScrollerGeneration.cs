using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerGeneration : MonoBehaviour {

public GameObject[] mapPerfab1;
public GameObject[] mapPerfab2;
public GameObject[] mapPerfab3;
public GameObject[] mapPerfab4;
public GameObject[] mapPerfab5;

//The weight to choose mapList1,2,3 or 4
float[] map_Weight = {1f,0f,0f,0f,0f};

int preMapList = 0;
int mapListChoose = 0;
GameObject targetP;

Vector3 passedMap = new Vector3(34f,7.5f,0);
Vector3 spawnMap = new Vector3(0,7.5f,0);

	// Use this for initialization
	void Start () {
		targetP = GameObject.FindGameObjectWithTag ("Player");


	}
	
	
	// Update is called once per frame
	void Update () {
		levelChange();
		if(targetP.transform.position.x >= passedMap.x){
			mapSelect();
		
if(mapListChoose == 1){

int a = (Random.Range(0,mapPerfab1.Length-1));
						passedMap.x += 34f;
			spawnMap.x = passedMap.x + 34f;
 			Instantiate(mapPerfab1[a], spawnMap, Quaternion.identity);

}else if(mapListChoose == 2){
	int a = (Random.Range(0,mapPerfab2.Length-1));
						passedMap.x += 34f;
			spawnMap.x = passedMap.x + 34f;
 			Instantiate(mapPerfab2[a], spawnMap, Quaternion.identity);

}else if(mapListChoose == 3){
	int a = (Random.Range(0,mapPerfab3.Length-1));
						passedMap.x += 34f;
			spawnMap.x = passedMap.x + 34f;
 			Instantiate(mapPerfab3[a], spawnMap, Quaternion.identity);


}else if(mapListChoose == 4){
	int a = (Random.Range(0,mapPerfab4.Length-1));
						passedMap.x += 34f;
			spawnMap.x = passedMap.x + 34f;
 			Instantiate(mapPerfab4[a], spawnMap, Quaternion.identity);

}else{
	int a = (Random.Range(0,mapPerfab5.Length-1));
						passedMap.x += 34f;
			spawnMap.x = passedMap.x + 34f;
 			Instantiate(mapPerfab5[a], spawnMap, Quaternion.identity);

}

	 
		}

		
	}




// The possibility of spawning empty change base on the distance of player.
public void levelChange(){

if(GameMaster.playerScore == 300 ){

map_Weight[0] = 0.5f;
map_Weight[1] = 0.4f;
map_Weight[2] = 0.1f;
map_Weight[3] = 0f;
map_Weight[4]=0f;
}else if(GameMaster.playerScore == 600){


map_Weight[0] = 0.2f;
map_Weight[1] = 0.6f;
map_Weight[2] = 0.2f;
map_Weight[3] = 0f;
map_Weight[4]=0f;
}else if(GameMaster.playerScore == 900){


map_Weight[0] = 0f;
map_Weight[1] = 0.2f;
map_Weight[2] = 0.6f;
map_Weight[3] = 0.2f;
map_Weight[4]=0.0f;
}else if(GameMaster.playerScore == 1200){


map_Weight[0] = 0f;
map_Weight[1] = 0f;
map_Weight[2] = 0.2f;
map_Weight[3] = 0.6f;
map_Weight[4]=0.2f;
}else if(GameMaster.playerScore == 500){
	return;
}

}

//Choose a suitable map add to previous map tail
	public void mapSelect(){


	if (preMapList == 0){

	weightSet();
	preMapList = mapListChoose;

	
	}else{
	weightSet();
	preMapList = mapListChoose;

}

	}

	public void weightSet(){

			float bid = Random.Range(0f, 1f);
		for(int i= 0; i< map_Weight.Length; i++){
			bid -= map_Weight [i];
			if(bid <= 0){
			
				mapListChoose = i+1;
				return;
			}
		}
	}
}
