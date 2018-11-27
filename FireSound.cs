using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour {


    private GameObject player;

    Vector2 direction = new Vector2(0, 0);

    private float Distance = 1f;

    private bool isPlaying = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(GameMaster.startlevel)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            direction = player.transform.position - transform.position;
            Distance = Vector2.Distance(transform.position, player.transform.position);

            if(Distance<30 && !isPlaying)
            {
                FindObjectOfType<AudioManager>().Play("Flames");
                isPlaying = true;
            }
        }
    }
}
