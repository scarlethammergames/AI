using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	//public float height;
	//public float radius;

	public Transform nextWaypoint;


	// Use this for initialization
	void Start () {
	

	}
	
	public Transform getNextWaypoint()
	{

		return this.nextWaypoint;

	}



}
