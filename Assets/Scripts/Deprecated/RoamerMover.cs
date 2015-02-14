using UnityEngine;
using System.Collections;

public class RoamerMover : MonoBehaviour {

	public int attackStrength = 10;
	private NavMeshAgent agent;
	private string objectHit;
	public bool foundPlayer;

	public Transform target;
	
	// Use this for initialization
	void Start () {

		foundPlayer = false;
	
		agent = GetComponent<NavMeshAgent> ();

	}


	// Update is called once per frame
	void Update () {

		agent.SetDestination(target.position);

	}


	public void setTarget(Transform newPosition)
	{

		target = newPosition;

				
	}

	public void playerFound(Transform newPosition)
	{
		foundPlayer = true;
		target = newPosition;
		gameObject.renderer.material.color = Color.red;

	}
	
	void OnCollisionEnter(Collision other)
	{
		
		objectHit = other.gameObject.tag;
		
		
		if(objectHit.Equals("Player"))
		{
			
			Debug.Log ("Hit");
			//Damage the player by taking health away from him/her
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.decreaseHealth(attackStrength);
		}
		
		if(objectHit.Equals ("EnviroTile"))
		{
			
			Debug.Log ("NomNomNom");
			Destroy(other.gameObject);
			
		}
		
		if(objectHit.Equals ("ResouceDepot") || objectHit.Equals ("RemoteDepot"))
		{
			
			Debug.Log ("Taking Resoruce");
			//TODO
			//Remove x amount from the main resource pool and if hitting the remote depot then damage it as well
		}
		
	}

}
