using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private Transform groundCheck;
	private float direction = 1;
	private float orpos, endpos;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		groundCheck = GameObject.Find("GroundCheck").transform;
		animator = GetComponent<Animator>();
	}

	void Start()
	{
		orpos = transform.position.x;
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
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			//LOSE RAZOR
		}
	}

	public void DestroyEnemy()
	{
		Destroy(this.gameObject);
	}

}
