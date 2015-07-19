using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

	private Transform groundCheck;
	private float direction = 1;
	private Animator animator;
	private Collider2D[] colliders;
	private ParticleSystem cotton;
	public float speed = 3;

	// Use this for initialization
	void Awake()
	{
		groundCheck = transform.FindChild("GroundCheck");
		animator = GetComponent<Animator>();
		colliders = GetComponents<Collider2D>();
		cotton = transform.FindChild("Cotton").GetComponent<ParticleSystem>();
	}

	void Start()
	{
		StartCoroutine(EnemyMovement());
		RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down);
		if (hit.collider != null)
		{
			if (hit.collider.tag != "Ground")
			{
				Destroy(this.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		direction = transform.localScale.x;
		transform.Translate(Vector3.left * direction * speed * Time.deltaTime);
		if (groundCheck == null) return;
		RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down);
		if (hit.collider != null && hit.collider.tag != "Player" && hit.collider.tag != "Enemy" && hit.collider.tag != "Crate")
		{
			if (hit.collider.tag != "Ground")
			{
				Flip();
			}
		}
		else if (hit.collider == null) Flip();
	}

	public void Flip()
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
			Manager.Instance.AddScore(100);
			Death();
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
		Manager.Instance.AddScore(30);
		CameraShakeScript.Instance.Shake(0.1f, 0.2f);
		Destroy(this.gameObject);
	}

	public void Death()
	{
		foreach (Collider2D c in colliders) c.enabled = false;
		//transform.SetParent(null);
		speed = 0;
		animator.SetBool("Death", true);
		cotton.Emit(30);
	}

}
