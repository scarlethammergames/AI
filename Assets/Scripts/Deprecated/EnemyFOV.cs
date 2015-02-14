using UnityEngine;
using System.Collections;

public class EnemyFOV : MonoBehaviour {

	private Vector3 moveTowards;
	public Transform player;
	public float speed;
	public float timeToChange;
	private bool chasing;
	private Vector3 inc;
	// Use this for initialization
	void Start () {

		inc = new Vector3 (1, 0, 1);

		chasing = false;

		moveTowards = new Vector3 (Random.Range (0.0f, 100.0f), 0.0f, Random.Range (0.0f, 100.0f));

	}

	// Update is called once per frame
	void FixedUpdate () {
	
		if(chasing){

			transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
		
		}else {
			moveTowards = moveTowards + inc;
			transform.position = Vector3.MoveTowards (transform.position, moveTowards, speed*Time.deltaTime);
		
		}

	}


	void Update(){

		if((Time.time % timeToChange) == 0){

			moveTowards = new Vector3 (Random.Range (0.0f, 100.0f), 0.0f, Random.Range (0.0f, 100.0f));

		}

		//Debug.Log (Time.time % timeToChange);
		Debug.Log (chasing);

	}



	void OnTriggerEnter(Collider other){

		if(other.tag == "Player"){

			//player = other.gameObject;

			chasing = true;

		}

	}





}
