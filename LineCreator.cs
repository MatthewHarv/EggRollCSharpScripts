using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {
	public GameObject firstmouse;
	Line activeLine;
public float timeLeft=5;
public bool usingline=false;
    private Vector3 lastMousePosition;
public float checkdifference;
 public float barDisplay; //current progress
private float countedline=0;
private int increaseduppunshment=1;
void start(){
	lastMousePosition=Input.mousePosition;
}
	void Update ()
	{
        if (GameMaster.inklevelbar==barDisplay&&Input.GetMouseButton(0)&&lastMousePosition!=Input.mousePosition){

		timeLeft=timeLeft-0.01f*increaseduppunshment;
		lastMousePosition=Input.mousePosition;
	increaseduppunshment++;
		} else{
			increaseduppunshment=1;
		}
		GameMaster.inklevelbar=barDisplay;



		if(GameMaster.startlevel){
     barDisplay = timeLeft/5;
	
if(usingline==false&&timeLeft<5){
	timeLeft+=Time.deltaTime/2;
}
if(GameMaster.inkpoweredup){
	timeLeft=5;
}

if(usingline==true){

	timeLeft-=(	activeLine.GetComponent<LineRenderer>().bounds.size.magnitude/20-countedline);
	countedline=activeLine.GetComponent<LineRenderer>().bounds.size.magnitude/20;
}

		if (Input.GetMouseButtonDown(0)&&GameMaster.ispaused==false)
		{
			usingline=true;
	
			GameObject lineGO = Instantiate(firstmouse);
			activeLine = lineGO.GetComponent<Line>();

            FindObjectOfType<AudioManager>().Play("DrawingAudio");
                
		
		}

		if (Input.GetMouseButtonUp(0)||GameMaster.allowdraw==false||timeLeft <0||GameMaster.ispaused==true)
		{
		
			countedline=0;
			usingline=false;
		activeLine = null;
                FindObjectOfType<AudioManager>().Stop("DrawingAudio");

            }
		

		if (activeLine != null)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			activeLine.UpdateLine(mousePos);
			
		}


}
	}

   }



