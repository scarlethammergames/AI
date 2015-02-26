using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour {

	private NavMeshAgent navAgent;

	void Start()
	{

		this.navAgent = GetComponent<NavMeshAgent> ();

		
	}

	void Update()
	{


	}

	public void SetPosition(Transform newTarget)
	{

		this.navAgent.SetDestination (newTarget.position);

	}



}
