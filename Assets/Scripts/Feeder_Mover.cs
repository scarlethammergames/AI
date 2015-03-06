using UnityEngine;
using System.Collections;

public class Feeder_Mover : AI_Mover {

	Transform tempTarget;
	bool isFeeding;
	public float timeUntilBored;
	public float smellingRadius;
	public float pullRadius;
	public float pullForce;
	private int resourcesEaten;
	public GameObject EnviroTile;
	private float tempSpeed;

	// Use this for initialization
	void Start ()
	{
		//setting agent
		this.agent = GetComponent<NavMeshAgent> ();
		
		gameObject.renderer.material.color = Color.magenta;

		updateSmellRange ();
		
	}


	void updateSmellRange()
	{

		SphereCollider myCollider = gameObject.GetComponentInChildren<Sphere_Of_Influence_Feeder>().gameObject.transform.GetComponent<SphereCollider>();
		myCollider.radius = this.smellingRadius;

	}


	// Update is called once per frame
	void Update () 
	{
		
		move ();
		
	}

	void FixedUpdate()
	{
		if(interested){
		
			tempSpeed = agent.speed;
			agent.speed = 0.0f;
			
			foreach(Collider collider in Physics.OverlapSphere(gameObject.transform.position, pullRadius))
			{
				if(collider.gameObject.tag.Equals("EnviroTile"))
				{
					Debug.Log ("NOMNOM PULL");
					
					Vector3 directedForce = transform.position - collider.transform.position;
					
					collider.rigidbody.AddForce (directedForce.normalized * pullForce * Time.deltaTime);
				}
			
			}
		
			notInterested ();
		}

	}


	public void setTempTarget(Transform nextWaypoint)
	{

		this.tempTarget = nextWaypoint;

	}


	public override void isInterested()
	{
		
		this.interested = true;

		gameObject.renderer.material.color = Color.yellow;

		//react ();

	}


	protected override void react()
	{

		this.waypoint = this.tempTarget;
		
	}
	/*
	IEnumerator falcuhnPuuull()
	{
		tempSpeed = agent.speed;
		agent.speed = 0.0f;

		foreach(Collider collider in Physics.OverlapSphere(gameObject.transform.position, pullRadius))
		{
			if(collider.gameObject.tag.Equals("EnviroTile"))
			{
				Debug.Log ("NOMNOM PULL");
				
				Vector3 directedForce = transform.position - collider.transform.position;
				
				collider.rigidbody.AddForce (directedForce.normalized * pullForce * Time.deltaTime);
			}

		}

		yield return new WaitForSeconds (4.0f);
		notInterested ();


	}*/

	public void kill()
	{
		//update text?

		int i = 0;
		GameObject tempGameObj;
		while(i < resourcesEaten)
		{

			tempGameObj = Instantiate(EnviroTile, transform.position, Quaternion.identity) as GameObject;

		}

		Destroy (this.gameObject);

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
			
			this.Health = this.Health - damageTaken;
			
		}
		else if(other.gameObject.tag.Equals("EnviroTile"))
		{
			resourcesEaten++;

			Destroy (other.gameObject);
			/*DEPRECATED
			//OMNOMNOMTEXT
			Debug.Log ("NOM");
			gameObject.renderer.material.color = Color.yellow;

			//StartCoroutine(noMoreFood());

			other.gameObject.Destroy();
			*/

		}
		
	}


	public void notInterested()
	{

		agent.speed = tempSpeed;

		this.interested = false;

		//updateWaypoint (this.prevWaypoint);

		gameObject.renderer.material.color = Color.magenta;

		SphereCollider myCollider = gameObject.GetComponentInChildren<Sphere_Of_Influence_Feeder>().gameObject.transform.GetComponent<SphereCollider>();
		myCollider.radius = this.smellingRadius;

	}

}
