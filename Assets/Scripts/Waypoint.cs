using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	//public float height;
	//public float radius;

	public Transform nextWaypoint;


	// Use this for initialization
	void Start () {
	
		//CapsuleCollider cc = GetComponent<CapsuleCollider> ();
		//cc.height = height;
		//cc.radius = radius;

	}
	
	public Transform getNextWaypoint()
	{

		return this.nextWaypoint;

	}

	void OnTriggerEnter(Collider other)
	{

		Debug.Log ("Hit");

	}

}
