using UnityEngine;
using System.Collections;

public class Feeder_Mover : AI_Mover {

	Transform tempTarget;

	// Use this for initialization
	void Start ()
	{
		
		//setting agent
		this.agent = GetComponent<NavMeshAgent> ();
		
		gameObject.renderer.material.color = Color.magenta;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		move ();

		gameObject.renderer.material.color = Color.magenta;

		
	}

	public void setTempTarget(Transform nextWaypoint)
	{

		this.tempTarget = nextWaypoint;

	}

	public override void isInterested()
	{
		
		this.interested = true;

		react ();
		
	}

	protected override void react()
	{
		//Debug.Log ("reacting");
		this.waypoint = this.tempTarget;
		
	}

	protected void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject.tag.Equals ("projectile") || other.gameObject.tag.Equals ("Projectile"))
		{
			
			Destroy (other.gameObject);
			
			if(this.Health <= 0)
			{
				
				Destroy (gameObject);
				
				return;
				
			}	
			
			this.Health -= damageTaken;
			
		}
		else if(other.gameObject.tag.Equals("EnviroTile"))
		{

			//OMNOMNOMTEXT

			gameObject.renderer.material.color = Color.yellow;

			this.interested = false;

			Destroy (other.gameObject);

		}
		
	}

	public void notInterested()
	{
		
		this.interested = false;

		Transform tempWaypoint = this.waypoint;

		this.waypoint = this.prevWaypoint;

		this.prevWaypoint = tempWaypoint;

	}

}
