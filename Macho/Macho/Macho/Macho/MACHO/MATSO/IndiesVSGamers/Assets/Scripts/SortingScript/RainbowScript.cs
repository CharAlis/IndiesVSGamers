using UnityEngine;
using System.Collections;

public class RainbowScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Manager.Instance.GameOver();
		}
	}
}
