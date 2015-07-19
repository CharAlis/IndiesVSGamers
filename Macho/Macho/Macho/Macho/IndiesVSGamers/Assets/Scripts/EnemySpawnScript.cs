using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	private float platformSize;
	public GameObject enemy;
	private GameObject spawned;
	void Awake() {
		platformSize = transform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Start() {
		int j =(int)Random.Range(MovingPlatform.Instance.speed/3, MovingPlatform.Instance.speed);
		for (int i = 0; i < j ; i++)
		{
			spawned = Instantiate(enemy, new Vector3(transform.position.x + (Random.Range(-1,1) * Random.Range(0, platformSize / 3)), 2.4f, 0),Quaternion.identity) as GameObject;
			spawned.transform.SetParent(transform);
		}
	}
}
