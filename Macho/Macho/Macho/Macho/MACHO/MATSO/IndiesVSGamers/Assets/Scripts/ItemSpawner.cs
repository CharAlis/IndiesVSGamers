using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{

	public GameObject item;

	private GameObject spawned;
	private BoxCollider2D col;

	void Awake()
	{
		col = transform.GetComponent<BoxCollider2D>();
	}

	void Start()
	{
		if (Random.value < 0.25f)
		{
			spawned = Instantiate(item, new Vector3(transform.position.x + (Random.Range(0f, 2f) - 1f) * col.bounds.extents.x + col.offset.x, transform.position.y - col.offset.y + 0.55f), Quaternion.identity) as GameObject;
			spawned.transform.SetParent(transform);
		}
	}
}
