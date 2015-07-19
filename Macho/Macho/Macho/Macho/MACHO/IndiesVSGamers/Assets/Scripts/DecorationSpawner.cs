using UnityEngine;
using System.Collections;

public class DecorationSpawner : MonoBehaviour {

	public GameObject item;
	
	private GameObject spawned;
	private BoxCollider2D col;
	
	void Awake() {
		col = transform.GetComponent<BoxCollider2D>();
	}
	
	void Start () {
		if (Random.value < 1) {
			spawned = Instantiate(item, new Vector3(transform.position.x + (Random.Range(0f,2f) - 1f)* col.bounds.extents.x + col.offset.x,  transform.position.y - col.offset.y + 1f, -1 ), Quaternion.identity) as GameObject;
			spawned.transform.SetParent(transform);
		}
	}

}
