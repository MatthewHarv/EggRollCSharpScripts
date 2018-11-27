using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
//
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	public SurfaceEffector2D surfaceEffector;

	List<Vector2> points;
	public void UpdateLine (Vector2 mousePos)
	{
		if (points == null)
		{
			points = new List<Vector2>();
			SetPoint(mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(), mousePos) > .1f){
			SetPoint(mousePos);
		}
	}

	void SetPoint (Vector2 point)
	{
		points.Add(point);

		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPosition(points.Count - 1, point);
		

		if (points.Count > 1){
			edgeCol.points = points.ToArray();
		}
	}
void OnCollisionEnter2D(Collision2D other)
{
	if(other.gameObject.tag=="Player"){
	
		     Vector3 normal = other.contacts[0].normal;
		if (normal.y > 0) { //if the bottom side hit change direction
	  surfaceEffector.speed= -1f;
    } 
	} else{
		lineRenderer.startColor=Color.black;
		lineRenderer.endColor=Color.black;
		surfaceEffector.speed=0f;
	}
	}


void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.CompareTag("FireBall")){
			other.gameObject.SetActive(false);
		}  

	}
}


