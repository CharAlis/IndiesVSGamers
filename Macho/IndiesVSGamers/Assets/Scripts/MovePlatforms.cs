using UnityEngine;
using System.Collections;

public class MovePlatforms : MonoBehaviour {

	public int size = 1;

	void Update()
	{
		transform.Translate(Vector3.left * MovingPlatform.Instance.speed * Time.deltaTime);
	}
}
