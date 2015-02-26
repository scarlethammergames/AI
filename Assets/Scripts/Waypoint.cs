using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	//public float height;
	//public float radius;

	public Transform nextWaypoint;

	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals ("Killer") && !other.gameObject.GetComponent<Killer_Mover>().interest() )
		{
			Debug.Log (this.gameObject.name);
			
			other.gameObject.GetComponent<Killer_Mover>().updateWaypoint(this.nextWaypoint);
			
		}

	}


}
