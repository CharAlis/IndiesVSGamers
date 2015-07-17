using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public GameObject[] sprites;
	public float minx = 0;
	public float maxx = 0;
	public float miny = 0;
	public float maxy = 0;

	void Start()
	{
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		while (true)
		{
			int num = Random.Range(0, sprites.Length);
			float counter = 0;
			Instantiate(sprites[num], transform.position, Quaternion.identity);
			float waitDistance = Random.Range(minx, maxx) * sprites[num].GetComponent<MovePlatforms>().size;
			while (counter < waitDistance)
			{
				counter += MovingPlatform.Instance.speed * Time.deltaTime;
				yield return null;
			}
			yield return null;
		}
	}
	
}
