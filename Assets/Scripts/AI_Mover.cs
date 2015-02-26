using UnityEngine;
using System.Collections;

public class AI_Mover : MonoBehaviour {


	protected NavMeshAgent agent;
	public Transform waypoint;
	protected bool interested;
	protected Transform prevWaypoint;
	public int Health;

	public bool interest()
	{

		return interested;

	}


	public void isInterested()
	{

		this.interested = true;

		gameObject.renderer.material.color = Color.red;
	
		react ();

	}

	public Transform getPosition()
	{
		
		return this.transform;
		
	}

	public void updateWaypoint(Transform nextWaypoint)
	{

		this.prevWaypoint = this.waypoint;
		
		this.waypoint = nextWaypoint;

	}
	

	protected void move()
	{
		
		this.agent.SetDestination (this.waypoint.position);

	}

	void react()
	{
		Debug.Log ("reacting");
		updateWaypoint (GameObject.FindGameObjectWithTag ("Player").gameObject.transform);
		
	}


	public void notInterested()
	{

		this.interested = false;

		this.waypoint = this.prevWaypoint;

		gameObject.renderer.material.color = Color.green;

	}
	

	//protected virtual void react() {}

	//void lostPlayer() {}

	//IEnumerator lost_player_timer() {}

}
