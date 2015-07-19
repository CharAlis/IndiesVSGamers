using UnityEngine;
using System.Collections;

public class ButterflySpawner : MonoBehaviour {

	public GameObject Butterfly;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnButterfly());
	}
	
	IEnumerator SpawnButterfly()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(40,80)/MovingPlatform.Instance.speed);
			Instantiate(Butterfly, transform.position, Quaternion.identity);
		}
		yield return null;
	}
}
