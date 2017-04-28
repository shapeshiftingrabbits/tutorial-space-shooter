using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rigidBody;

	public float speed;

	public float tilt;

	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpwan;

	private float nextFire;
	public float fireRate;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}

	//called once before rendering the frame every frame.
	void Update () {

		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot, shotSpwan.position, shotSpwan.rotation);// as GameObject;
		}
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidBody.velocity = movement * speed;

		rigidBody.position = new Vector3(
			Mathf.Clamp(rigidBody.position.x, boundary.xMin,  boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidBody.position.z,  boundary.zMin,  boundary.zMax)
		);

		rigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidBody.velocity.x * (-tilt));
	}
}
