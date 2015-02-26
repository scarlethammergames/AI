using UnityEngine;
using System.Collections;

public class AI_Mover : MonoBehaviour {


	protected NavMeshAgent agent;
	public Transform waypoint;
	protected bool interested;
	protected Transform prevWaypoint;

	

	protected void OnTriggerEnter(Collider other)
	{

		Debug.Log ("SHIEEEEIT");

		if(other.tag.Equals ("Waypoint") && !interested)
		{
			
			updateWaypoint(other.gameObject.GetComponent<Waypoint>().getNextWaypoint());
			
		}
		
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

	protected void updateWaypoint(Transform nextWaypoint)
	{

		this.prevWaypoint = this.waypoint;
		
		this.waypoint = nextWaypoint;

	}
	

	protected void move()
	{
		
		agent.SetDestination (this.waypoint.position);

	}

	void react()
	{
		Debug.Log ("reacting");
		updateWaypoint (GameObject.FindGameObjectWithTag ("Player").gameObject.transform);
		
	}
	
	//protected virtual void react() {}

	//void lostPlayer() {}

	//IEnumerator lost_player_timer() {}

}
