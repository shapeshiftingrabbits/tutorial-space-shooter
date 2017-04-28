using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;

	private Rigidbody rigidBody;

	//called when the first frame is generated.
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity = transform.forward * speed;				
	}
}
      