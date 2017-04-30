﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject hazard;

	public Vector3 spawnValues;

	void Start () {
		SpawnWaves ();
	}

	void SpawnWaves (){
		Vector3 spwanPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (hazard, spwanPosition, spawnRotation);
	}
}
