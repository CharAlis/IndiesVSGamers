using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 0;
	private Vector3 difference;
	private float rotZ;
	// Update is called once per frame
	void Update () {
		if (!PauseGame.isPaused)
		{
			//Subtracting the position of the player from the mouse position
			difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			difference.Normalize();		//Normalizing the vector. Meaning that all the sum of the vector will be equal to one.

			rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;	//Find the angle in degrees
			if (difference.x > 0) transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
			else
			{
				rotZ = Mathf.Atan2(-difference.y, difference.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset - 190);
			}
		}
	}
}
