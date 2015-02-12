using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {


	
	// Update is called once per frame
	void FixedUpdate () {
	
		float getHor = Input.GetAxis ("Horizontal");
		float getVer = Input.GetAxis ("Vertical");

		rigidbody.AddForce (getHor, 0.0f, getVer);

	}
}
