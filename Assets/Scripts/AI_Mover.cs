using UnityEngine;
using System.Collections;

public class AI_Mover : MonoBehaviour {


	private NavMeshAgent agent;
	private Transform waypoint;
	private bool interested;
	private Transform prevWaypoint;


	// Use this for initialization
	void Start () {
		
		//setting agent
		this.agent = GetComponent<NavMeshAgent> ();
		
		this.waypoint = GameObject.FindWithTag ("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
	

		if( interested )
		{

			react ();
		}
		else
		{

			move ();

		}


	}

	//sets the next waypoint for the nav point to move towards
	public void setWaypoint(Transform nextWaypoint)
	{

		this.prevWaypoint = this.waypoint;

		this.waypoint = nextWaypoint;
		
	}
	
	public Transform getPosition()
	{
		
		return this.transform;
		
	}

	void move(){
		
		agent.SetDestination (this.waypoint.position);

	}
	
	void react() {}

	//void lostPlayer() {}

	//IEnumerator lost_player_timer() {}

}
