using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public Transform nextWaypoint;


	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals("Roamer") )
		{
			if(!other.gameObject.GetComponent<RoamerMover>().foundPlayer){

				other.gameObject.GetComponent<RoamerMover>().setTarget(nextWaypoint);

			}
		}

	}
}
