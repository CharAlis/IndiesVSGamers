using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private Transform groundCheck;
	private float direction = 1;
	private Animator animator;
	private Collider2D[] colliders;
	private ParticleSystem cotton;

	// Use this for initialization
	void Awake () {
		groundCheck = GameObject.Find("GroundCheck").transform;
		animator = GetComponent<Animator>();
		colliders = GetComponents<Collider2D>();
		cotton = GameObject.Find("Cotton").GetComponent<ParticleSystem>();
	}

	void Start()
	{
		StartCoroutine(EnemyMovement());
	}
	
	// Update is called once per frame
	void Update () {
		direction = transform.localScale.x;
		transform.Translate(Vector3.left * direction * 5 * Time.deltaTime);
		RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down);
		if (hit.collider != null)
		{
			if (hit.collider.tag != "Ground")
			{
				Flip();
			}
		}
		else Flip();
	}

	void Flip()
	{
		transform.localScale = new Vector3(transform.localScale.x * (-1), 1, 1);
	}

	IEnumerator EnemyMovement()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(2, 4));
			Flip();
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			animator.SetBool("isStomped", true);
			foreach (Collider2D c in colliders) c.enabled = false;
			Brockontroller.Instance.StompJump();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			Manager.Instance.LoseRazor();
			foreach (Collider2D c in colliders) c.enabled = false;
		}
	}

	public void DestroyEnemy()
	{
		Destroy(this.gameObject);
	}

	public void Death()
	{
		transform.SetParent(null);
		animator.SetBool("Death", true);
		cotton.Emit(30);
	}

}
