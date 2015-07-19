using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

	public float speed = 5f;
	public int range = 0;
	
	private Transform player;
	
	void Awake() {
		player = GameObject.FindWithTag("Player").transform;
	}
	
	void Update () {
		transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, player.position) >= (float)((range==0)?(5):((range==1)?(7):(15)))) {
			Destroy (this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") return;
		if (col.tag == "Enemy") col.transform.GetComponent<EnemyScript>().Death();
		//	Destroy(col.gameObject);
		Destroy (this.gameObject);	//col.transform.GetComponent<EnemyScript>().
		if (col.tag == "Crate") col.SendMessage("DropItem");
	}

}
