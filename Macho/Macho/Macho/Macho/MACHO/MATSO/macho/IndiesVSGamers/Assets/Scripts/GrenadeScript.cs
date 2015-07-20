using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour
{
    public float radius = 3.0f;
	private Vector2 grenadeOrigin;
	private Animator animator;
	private Rigidbody2D rb;
    private AudioSource source;

	void Awake()
	{
		animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.right * 15, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground" || col.tag == "Enemy" || col.tag == "Rainbow")
		{
			Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
			foreach (Collider2D c in cols)
			{
                source.Play();
				animator.SetTrigger("Kaboom");
				rb.velocity = Vector3.zero;
				rb.isKinematic = true;
				if (c.tag == "Enemy") c.transform.GetComponent<EnemyScript>().Death();
				if (c.tag == "Player") c.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
			}
		}
	}

	public void DestroyGrenade()
	{
		Destroy(this.gameObject);
	}

	//IEnumerator Explode()
	//{
	//	//Instantiate(grenade, transform.position, transform.rotation);
	//	grenadeOrigin = transform.position;
	//	Collider2D[] cols = Physics2D.OverlapCircleAll(grenadeOrigin, radius);

	//	foreach(Collider2D hit in cols)
	//	{
	//		if (hit.tag == "Enemy") hit.transform.GetComponent<EnemyScript>().Death();
	//	}

	//	new WaitForSeconds(0.6f);
	//	Destroy(gameObject);
	//	yield return null;
	//}
}
