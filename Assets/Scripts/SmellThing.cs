using UnityEngine;
using System.Collections;

public class SmellThing : MonoBehaviour {
	

	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals("Player"))
		{

			//chases player once it smells him/her
			gameObject.GetComponent<SnifferMover>().setTarget(other.gameObject.transform, true);
			return;

		}

		//goes after player first. Also encounters resources, supply depot, and remote depots
		if(other.tag.Equals ("EnviroTile")|| other.tag.Equals ("ResourceDepot") || other.tag.Equals("RemoteDepot"))
		{
			gameObject.GetComponent<SnifferMover>().setTarget(other.gameObject.transform, false);
		}



	}

}
