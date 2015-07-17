﻿using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 0;

	// Update is called once per frame
	void Update () {
		//Subtracting the position of the player from the mouse position
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize ();		//Normalizing the vector. Meaning that all the sum of the vector will be equal to one.

		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;	//Find the angle in degrees
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
	}
}