using UnityEngine;
using System.Collections;

public class Sphere_Of_Influence : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		
		Debug.Log ("OOGABOOGAMOFUGA");
		
		if(other.tag.Equals ("Player"))
		{
			
			GetComponentInParent<Killer_Mover>().isInterested();
			
		}
		
	}

}
