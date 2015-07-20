using UnityEngine;
using System.Collections;

public class BordersLocation : MonoBehaviour {

	public bool isLeft = false;
	// Use this for initialization
	void Awake () {
		if (isLeft)
		{
			transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, 0f);
		}
		else
		{
			transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x, 0f);
		}
	}

}
