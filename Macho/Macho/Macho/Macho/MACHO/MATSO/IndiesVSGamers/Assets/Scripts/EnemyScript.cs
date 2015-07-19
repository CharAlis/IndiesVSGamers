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
	public bool isFlying = false;

	// Use this for initialization
	void Awake()
	{
		animator = GetComponent<Animator>();
		if (!isFlying)
		{
			groundCheck = transform.FindChild("GroundCheck");
			colliders = GetComponents<Collider2D>();
			cotton = transform.FindChild("Cotton").GetComponent<ParticleSystem>();
		}
	}

	void Start()
	{
		if (!isFlying)
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
	}

	// Update is called once per frame
	void Update()
	{
		if (!isFlying)
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
			if (!isFlying) foreach (Collider2D c in colliders) c.enabled = false;
			Brockontroller.Instance.StompJump();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			Manager.Instance.LoseRazor();
			if (!isFlying) foreach (Collider2D c in colliders) c.enabled = false;
		}
	}

	public void DestroyEnemy()
	{
		Manager.Instance.AddScore(30);
		Destroy(this.gameObject);
	}

	public void Death()
	{
		if (!isFlying) foreach (Collider2D c in colliders) c.enabled = false;
		//transform.SetParent(null);
		CameraShakeScript.Instance.Shake(0.1f, 0.1f);
		speed = 0;
		animator.SetBool("Death", true);
		if (!isFlying) cotton.Emit(30);
	}

}
