using UnityEngine;
using System.Collections;

public class AI_Mover : MonoBehaviour {


	protected NavMeshAgent agent;
	public Transform waypoint;
	protected bool interested;
	protected Transform prevWaypoint;
	public int Health;
	public int damageTaken;

	public bool interest()
	{

		return this.interested;

	}


	public virtual void isInterested()
	{	}

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

	protected virtual void react()
	{
	//	Debug.Log ("reacting");
	//	updateWaypoint (GameObject.FindGameObjectWithTag ("Player").gameObject.transform);
		
	}



	

}
