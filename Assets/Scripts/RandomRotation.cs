﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

	public float tumble;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
