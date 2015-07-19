using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    private float platformSize;
    public GameObject item;
    private GameObject spawned;

    void Awake() {
        platformSize = transform.GetComponent<BoxCollider2D>().size.x;
    }
	
	void Start () {
        if (Random.value < 0.3) {
            spawned = Instantiate(item, new Vector3(transform.position.x + (Random.Range(-1, 1) * Random.Range(0, platformSize / 3)), 2.8f, 0), Quaternion.identity) as GameObject;
            spawned.transform.SetParent(transform);
        }
	}
}
