using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float speed = 5.0f;
	public static MovingPlatform Instance;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		StartCoroutine(IncreaseSpeed());
	}

	IEnumerator IncreaseSpeed()
	{
		while (true)
		{
			if (speed < 15)
			{
				speed += 1f / 20f;
				yield return new WaitForSeconds(0.2f);
			}
			yield return null;
		}
	}
}
