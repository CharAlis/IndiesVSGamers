using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

	public float speed = 5f;
	public int range = 0;
	private Animator animator;
	private Transform player;
    private AudioSource source;
	
	void Awake() {
		player = GameObject.FindWithTag("Player").transform;
		animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}
	
	void Update () {
		transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
		if (Vector3.Distance(transform.position, player.position) >= (float)((range==0)?(5):((range==1)?(7):(15)))) {
			Destroy (this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") return;
		if (col.tag == "Enemy" || col.tag == "Ground" || col.tag == "Crate")
		{
            source.Play();
			animator.SetTrigger("Kaboom");
			speed = -MovingPlatform.Instance.speed;
			Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 3.0f);
			foreach (Collider2D c in cols)
			{
				if (c.tag == "Enemy") c.transform.GetComponent<EnemyScript>().Death();
			}
		}
		if (col.tag == "Crate") col.SendMessage("DropItem");
	}

	public void DestroyRocket()
	{
		Destroy(this.gameObject);
	}
}
