using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (!PauseGame.isPaused) transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
	}
}
