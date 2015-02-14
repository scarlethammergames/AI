using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public float height;
	public float radius;

	private Transform nextWaypoint;


	// Use this for initialization
	void Start () {
	
		CapsuleCollider cc = GetComponent<CapsuleCollider> ();
		cc.height = height;
		cc.radius = radius;

	}
	
	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals("Killer") )
		{
			//Tells killer to go to the nextWaypoint only if 
			//killer.setNextWaypoint(nextWaypoint);
		}

	}

	//assigns the waypoint that this waypoint will point to 
	public void setNextWaypoint(Transform waypoint)
	{

		this.nextWaypoint = waypoint;
	
	}


	
}
