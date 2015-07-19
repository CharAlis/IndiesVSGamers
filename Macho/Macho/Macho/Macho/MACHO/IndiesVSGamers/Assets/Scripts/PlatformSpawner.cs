using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{

	public GameObject[] sprites;
	public float minx = 0;
	public float maxx = 0;
	public float miny = 0;
	public float maxy = 0;

	private bool noPlatform = false;

	void Start()
	{
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		bool spawningPit = false;
		while (true)
		{
			if (noPlatform == false)
			{
				int num = Random.Range(0, sprites.Length);
				float counter = 0;
				float waitDistance = Random.Range(6, 10) + sprites[num].GetComponent<MovePlatforms>().size;

				Instantiate(sprites[num], new Vector3(transform.position.x, transform.position.y + Random.Range(-1f, 2f), transform.position.z), Quaternion.identity);
				while (!noPlatform) yield return null;
				while (counter < waitDistance)
				{
					counter += MovingPlatform.Instance.speed * Time.deltaTime;
					yield return null;
				}
				noPlatform = false;
				yield return null;
			}
			yield return null;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground")
			noPlatform = false;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Ground")
			noPlatform = true;
	}

}
