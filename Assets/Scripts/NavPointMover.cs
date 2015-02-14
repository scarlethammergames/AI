using UnityEngine;
using System.Collections;

public class NavPointMover : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform waypoint;
	private bool foundPlayer;

	// Use this for initialization
	void Start () {
	
		//setting agent
		this.agent = GetComponent<NavMeshAgent> ();

		waypoint = GameObject.FindWithTag ("Waypoint").transform;

	}

	void Move(){

		agent.SetDestination (waypoint.position);

	}

	//returns whether or not the nav point has seen the player
	public bool hasFoundPlayer()
	{

		return this.foundPlayer;

	}

	//sets the next waypoint for the nav point to move towards
	public void setWaypoint(Transform nextWaypoint)
	{

		this.waypoint = nextWaypoint;

	}

	public Transform getPosition()
	{

		return this.transform;

	}

	// Update is called once per frame
	void Update () {
	
		Move ();

	}
}
