using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMovement : MonoBehaviour {
	 Transform  player;
	private Vector3 offset;
	public float movementSpeed = 10.0f;
	private Vector3 playercurrentposition;

	private float backgroundMoveBack;

	public GameObject cloud;
	public GameObject sky;
	public GameObject trees;
	public GameObject City;

	public GameObject kitchenBk;

	public float cloudSpeed = 1f;
	public float skySpeed = 1f;
	public float treesSpeed = 1f;
	public float citySpeed = 1f;
	public float kitchenSpeed = 1f;

	Camera cam ;

	// Use this for initialization
	void Start () {
			player = GameObject.FindGameObjectWithTag ("Player").transform;		
			cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Scene scene = SceneManager.GetActiveScene();

		if (player) {

			if(scene.name == "MainLevel" && player.GetComponent<Player>().dead == false){

		backgroundMoveBack = (float)(GameMaster.playerScore * 0.01);

			Vector3 skyPosition = new Vector3(player.position.x + 6 - backgroundMoveBack*skySpeed, 5.5f, 0 );
			Vector3 cloudPosition = new Vector3(player.position.x + 8 - backgroundMoveBack*cloudSpeed, 7.5f, 0 );
			Vector3 treesPosition = new Vector3(player.position.x + 8 - backgroundMoveBack*treesSpeed, 7.5f, 0 );
			Vector3 cityPosition = new Vector3(player.position.x + 8 - backgroundMoveBack*citySpeed, 7.5f, 0 );
		

		
			sky.transform.position = Vector3.Lerp (transform.position, skyPosition, movementSpeed)+ new Vector3 (12, 0,0);
			cloud.transform.position = Vector3.Lerp (transform.position, cloudPosition, movementSpeed)+ new Vector3 (12, 0,0);
			City.transform.position = Vector3.Lerp (transform.position, cityPosition, movementSpeed)+ new Vector3 (12, -2, 0);
			trees.transform.position = Vector3.Lerp (transform.position, treesPosition, movementSpeed)+ new Vector3 (12, -2, -15);
			}else if(scene.name == "Kitchen"&& player.GetComponent<Player>().dead == false){
			
				backgroundMoveBack = (float)(GameMaster.playerScore * 0.01);
				Vector3 kitchenPosition = new Vector3(player.position.x + 8 - backgroundMoveBack*kitchenSpeed, 7.5f, 0 );
				kitchenBk.transform.position = Vector3.Lerp (transform.position, kitchenPosition, movementSpeed)+ new Vector3 (12, 0,0);
			}

			//transform.position = Vector3.Lerp (transform.position, camPosition, movementSpeed)+ new Vector3 (12, 0, 1);
		}else {
			player = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}
}
