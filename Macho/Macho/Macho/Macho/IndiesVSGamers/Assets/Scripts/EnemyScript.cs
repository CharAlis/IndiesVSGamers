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
		transform.Translate(Vector3.left * direction * 5 * Time.deltaTime);
		RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down);
		if (hit.collider != null && hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
		{
			if (hit.collider.tag != "Ground")
			{
				Flip();
			}
		}
		else Flip();
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
		Manager.Instance.AddScore(30);
		CameraShakeScript.Instance.Shake(0.1f, 0.2f);
		Destroy(this.gameObject);
	}

	public void Death()
	{
		transform.SetParent(null);
		animator.SetBool("Death", true);
		cotton.Emit(30);
	}

}
