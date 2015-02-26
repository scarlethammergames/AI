using UnityEngine;
using System.Collections;

public class Sphere_Of_Influence : MonoBehaviour {

	bool isRunning;

	void Start()
	{

		isRunning = false;

	}

	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals ("Player"))
		{

			//if (this.isRunning) {
				
			//	StopCoroutine ("lost_player_timer");

			//	this.isRunning = false;

			///	return;
			//	
			//}

			GetComponentInParent<Killer_Mover>().isInterested();
			
		}
		
	}

	void OnTriggerExit(Collider other)
	{

		if(other.tag.Equals("Player"))
		{

			StartCoroutine(lost_player_timer());

		}

	}

	IEnumerator lost_player_timer() 
	{

		this.isRunning = true;

		yield return new WaitForSeconds (5.0f);

		GetComponentInParent<Killer_Mover> ().notInterested ();

		yield return null;

	}
}
