using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
public Rigidbody2D rb;
public Sprite NormalEgg; 
public Sprite PoweredEgg; 
public Sprite InkedUpEgg; 
private bool beginbounce=true;
public Sprite eggcrack25; 
public Sprite eggcrack50; 
public Sprite eggcrack75;

public Sprite redegg;
    public float ImmunityPowerCount = 0;
public float speed;
int distanceTravelled = 0;

//int distanceFell=0;
Vector3 startingpositionx;
Vector3 startingpositiony;
public bool tookdamage=false;
	public int wayToDead = 0;
	public int respawnDelay = 0;

	Camera cam;

	Vector3 ashPosition;

public  bool dead = false;

void Start(){
	GameMaster.startlevel=false;
	rb=GetComponent<Rigidbody2D>();
	 startingpositionx.x = transform.position.x;
	  startingpositiony.y = transform.position.y;
	  GameMaster.playerfatigue=0;
	   this.gameObject.GetComponent<SpriteRenderer>().sprite=NormalEgg;
		cam =GameObject.Find("Main Camera").GetComponent<Camera>();


		Scene scene = SceneManager.GetActiveScene();
		if(scene.name == "Kitchen"){
			
			rb.transform.position=GameMaster.TutorialSpawner;
		}
		
}


	void Update (){
		if(Input.GetKeyDown(KeyCode.B)){
	
			Instantiate (GameMaster.GM.deadAnimation[1],this.transform.position, this.transform.rotation);
		}
if(GameMaster.inkpoweredup==false&&GameMaster.eggisimmune==false&&tookdamage==false){

	if(GameMaster.playerfatigue<25){
		this.gameObject.GetComponent<SpriteRenderer>().sprite=NormalEgg;
		}
	if(GameMaster.playerfatigue>24&&GameMaster.playerfatigue<50){
		this.gameObject.GetComponent<SpriteRenderer>().sprite=eggcrack25;
		}
	if(GameMaster.playerfatigue>49&&GameMaster.playerfatigue<75){
		this.gameObject.GetComponent<SpriteRenderer>().sprite=eggcrack50;
		}

	if(GameMaster.playerfatigue>74){
		this.gameObject.GetComponent<SpriteRenderer>().sprite=eggcrack75;
		}

	//GameMaster.healthbar=(100-GameMaster.playerfatigue)/100;
}
GameMaster.healthbar=(100-GameMaster.playerfatigue)/100;
		if(GameMaster.inkpoweredup){
			this.gameObject.GetComponent<SpriteRenderer>().sprite=InkedUpEgg;
			InkPoweredUpTimerStart();
		}

		distanceTravelled=Mathf.RoundToInt(transform.position.x-startingpositionx.x);


		GameMaster.playerScore=distanceTravelled;
		if(Input.GetKeyDown("r")){
			LoadBack();
		}

		if(GameMaster.eggisimmune)
        {


            this.gameObject.GetComponent<SpriteRenderer>().sprite = PoweredEgg;

        }
		if(GameMaster.playerfatigue>99){
				wayToDead = 1;
			
			LoadBack();
		}

		if(GameMaster.startlevel){
			if(beginbounce==true){
				Vector2 movement=new Vector2(0,1);
				rb.AddForce(movement*300);
				beginbounce=false;
			}
			if(GameMaster.ispaused==false){
			if(rb.velocity.magnitude<15){
	
				Vector2 movement=new Vector2(1,0);
				rb.AddForce(movement*speed);	
			}
			}
		}



	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.relativeVelocity.magnitude>20&&GameMaster.eggisimmune==false){
	GameMaster.playerfatigue+=(other.relativeVelocity.magnitude/2);
tookdamage=true;
this.gameObject.GetComponent<SpriteRenderer>().sprite=redegg;
Invoke("showdamage", 0.5f);
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
		}
			if(other.gameObject.CompareTag("Alien")||other.gameObject.CompareTag("Spikes")){
		if(GameMaster.eggisimmune==true){
			other.gameObject.SetActive(false);
			}else{
				wayToDead = 1;
	LoadBack();
		}
	}
	
	if(other.gameObject.CompareTag("FireTrap")){
		if(GameMaster.eggisimmune==false){
	LoadBack();
		} else{
			other.gameObject.SetActive(false);
		}
		}  
}  
void showdamage(){
tookdamage=false;
}
	


void OnTriggerEnter2D(Collider2D other){
	if(other.gameObject.CompareTag("Wall")){
	LoadBack();
		}  
		if(other.gameObject.CompareTag("FireBall")){
			if(GameMaster.eggisimmune==false){
				wayToDead = 3;
	LoadBack();
			} else{
				other.gameObject.SetActive(false);
			}
		}  
		if(other.gameObject.CompareTag("DeadZone")){
			wayToDead = 2;
			LoadBack();
		}
		
	if(other.gameObject.CompareTag("FireWall")){
		if(GameMaster.eggisimmune == false){
                FindObjectOfType<AudioManager>().Play("Flames");
				wayToDead = 3;
			LoadBack();
		}
		}
	if(other.gameObject.CompareTag("ImmunePowerup")){
		if(GameMaster.powerupcounter<4){
		other.gameObject.SetActive(false);
		GameMaster.powerupTriggered=true;
		}
		}
if(other.gameObject.CompareTag("InkPowerup")){
		other.gameObject.SetActive(false);
		GameMaster.inkpoweredup=true;
		}

		if(other.gameObject.CompareTag("LoadToMain")){
			GameMaster.showUI=false;
			GameMaster.startlevel=false;
			GameMaster.TutorialSpawner=new Vector3(-2.1f,-1.29f,0);
			SceneManager.LoadScene("MainLevel");
		}
			if(other.gameObject.CompareTag("Alien")){
				if(GameMaster.eggisimmune == false){
					LoadBack();
				}else{
		other.gameObject.SetActive(false);
				}
		}
	}

void OnMouseOver() {
	if(GameMaster.startlevel){
 		if(Input.GetMouseButton(0)){
	
	 GameMaster.allowdraw=false;
 }else{
	  GameMaster.allowdraw=true;
	  }
	}
}

void OnMouseExit()
{
	GameMaster.allowdraw=true;
}

void InkPoweredUpTimerStart(){
Invoke("InkedUpTimerEnd",6f);
}
void InkedUpTimerEnd(){
GameMaster.inkpoweredup=false;
}

// Could change to spawn a new player egg.
	public  void LoadBack(){


	GameMaster.startlevel=false;
	GameMaster.showUI=false;
	dead = true;
		if(this.enabled == true){

			if (wayToDead == 1) {
				GameObject eggLiquid = Instantiate (GameMaster.GM.deadAnimation [0], this.transform.position, this.transform.rotation);
				//eggLiquid.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform, true);
				Instantiate (GameMaster.GM.deadAnimation [1], this.transform.position, this.transform.rotation);
			} else if(wayToDead ==2){
				Instantiate (GameMaster.GM.deadAnimation [2], this.transform.position, Quaternion.identity);
			} else if (wayToDead ==3){
			 ashPosition = this.transform.position;
				GameObject ash = Instantiate (GameMaster.GM.deadAnimation [3], this.transform.position, Quaternion.identity);
				Invoke ("makeAsh", 1.3f);
			}
			//this.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;
			this.GetComponent<Renderer> ().enabled = false;
			this.GetComponent<PolygonCollider2D> ().enabled = false;
			this.GetComponent<Rigidbody2D> ().gravityScale = 0;
			this.transform.GetChild (0).gameObject.SetActive (false);
		this.enabled = false;
	
			cam.GetComponent<CameraController>().keepFollow = false;
	//	yield return new WaitForSeconds (respawnDelay);
		Invoke("resetPosition", respawnDelay);
		}

}

	void makeAsh(){
		Instantiate (GameMaster.GM.deadAnimation [4], ashPosition, Quaternion.identity);
	}

	void resetPosition(){
		Scene scene = SceneManager.GetActiveScene();

		this.GetComponent<Renderer> ().enabled = true;
		this.enabled = true;
		this.GetComponent<PolygonCollider2D> ().enabled = true;
		this.GetComponent<Rigidbody2D> ().gravityScale = 1;
		this.transform.GetChild (0).gameObject.SetActive (true);
dead = false;
		if(scene.name == "MainLevel"){
			GameMaster.highscorePlottingfinished=false;
	
			SceneManager.LoadScene("GameOver");
		}
		if(scene.name=="Kitchen"){
			GameMaster.powerupcounter=0;
			SceneManager.LoadScene("Kitchen");
	}
	}


}
