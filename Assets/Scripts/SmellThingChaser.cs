using UnityEngine;
using System.Collections;

public class SmellThingChaser : MonoBehaviour {
	

	void OnTriggerEnter(Collider other)
	{

		if(other.tag.Equals("Player"))
		{

			//chases player once it smells him/her
			gameObject.GetComponent<ChaserMover>().setTarget(other.gameObject.transform);
			return;

		}

		//goes after player first. Also encounters resources, supply depot, and remote depots
		if(other.tag.Equals ("EnviroTile") || other.tag.Equals ("ResourceDepot") || other.tag.Equals("RemoteDepot"))
		{
			gameObject.GetComponent<ChaserMover>().setTarget(other.gameObject.transform);
		}



	}

}
