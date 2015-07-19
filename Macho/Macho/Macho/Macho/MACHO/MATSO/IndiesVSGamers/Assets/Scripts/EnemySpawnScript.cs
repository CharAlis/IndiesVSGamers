using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject[] enemies;

	private GameObject spawned;
	private BoxCollider2D col;

	void Awake()
	{
		col = transform.GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Start()
	{
		int j = (int)Random.Range(MovingPlatform.Instance.speed / 3, MovingPlatform.Instance.speed);
		for (int i = 0; i < j; i++)
		{
			GameObject enemy = enemies[Random.Range(0, 2)];
			spawned = Instantiate(enemy, new Vector3(transform.position.x + (Random.Range(0f, 2f) - 1f) * col.bounds.extents.x + col.offset.x, transform.position.y - col.offset.y, 0), Quaternion.identity) as GameObject;
			spawned.transform.SetParent(transform);
		}
	}
}
