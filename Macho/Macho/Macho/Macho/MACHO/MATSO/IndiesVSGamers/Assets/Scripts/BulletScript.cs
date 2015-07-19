using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 15f;
	public int range = 0;

	private Transform player;

	void Awake() {
		player = GameObject.FindWithTag("Player").transform;
	}

	void Update () {
		transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, player.position) >= (range+1f)*5f) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") return;
		//if (col.tag == "Enemy") Destroy(col.gameObject);
		Destroy (this.gameObject);	//col.transform.GetComponent<EnemyScript>().
		if (col.tag == "Enemy") col.transform.GetComponent<EnemyScript>().Death();
		if (col.tag == "Crate") col.SendMessage("DropItem");
	}

}
