using UnityEngine;
using System.Collections;

public class Sphere_Of_Influence_Feeder : MonoBehaviour {



	void Start()
	{



	}


	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals ("EnviroTile") )
		{

			GetComponentInParent<Feeder_Mover>().setTempTarget (other.gameObject.transform);
			GetComponentInParent<Feeder_Mover>().isInterested ();
	
		}

		if(other.tag.Equals ("Player"))
		{

			GetComponentInParent<Feeder_Mover>().notInterested();

		}
		
	}


}
