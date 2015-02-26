using UnityEngine;
using System.Collections;

public class Feeder_Mover : AI_Mover {

	Transform tempTarget;
	bool isRunning;
	public float timeUntilBored;
	public float smellingRadius;

	// Use this for initialization
	void Start ()
	{

		isRunning = false;

		this.prevWaypoint = this.waypoint;

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

	public void setTempTarget(Transform nextWaypoint)
	{

		this.tempTarget = nextWaypoint;

	}

	public override void isInterested()
	{
		
		this.interested = true;

		gameObject.renderer.material.color = Color.yellow;

		react ();

	}

	protected override void react()
	{

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
			Debug.Log ("NOM");
			gameObject.renderer.material.color = Color.yellow;

			StartCoroutine(noMoreFood());

			other.gameObject.SetActive(false);

		}
		
	}

	IEnumerator noMoreFood()
	{

		isRunning = true;

		Debug.Log ("Now waiting");

		yield return new WaitForSeconds (this.timeUntilBored);

		Debug.Log ("Not interested");

		notInterested ();

	}

	public void notInterested()
	{

		StopCoroutine ("noMoreFood");

		this.isRunning = false;

		this.interested = false;

		//Transform tempWaypoint = this.waypoint;

		this.waypoint = this.prevWaypoint;

		//this.prevWaypoint = tempWaypoint;

		gameObject.renderer.material.color = Color.magenta;

		SphereCollider myCollider = gameObject.GetComponentInChildren<Sphere_Of_Influence_Feeder>().gameObject.transform.GetComponent<SphereCollider>();
		myCollider.radius = this.smellingRadius;
		

	}

}
