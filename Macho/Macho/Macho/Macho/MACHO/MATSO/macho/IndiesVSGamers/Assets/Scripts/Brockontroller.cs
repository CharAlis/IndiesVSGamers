using UnityEngine;
using System.Collections;

public class Brockontroller : MonoBehaviour {

	private Rigidbody2D rb;
	public bool canJump = false;
	public float jumpForce = 5;
	public float jumpShortSpeed = 5;
	public float speed = 5f;
	private bool jump;
	private bool jumpCancel;
	private Animator animator;
	public static Brockontroller Instance;
	private ParticleSystem hearts;

	void Awake()
	{
		Instance = this;
		hearts = transform.FindChild("HeartParticles").GetComponent<ParticleSystem>();
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		if (Input.GetButtonDown("Jump") && canJump)
		{
			jump = true;
			canJump = false;
		}
		if (Input.GetButtonUp("Jump") && !canJump)
		{
			jumpCancel = true;
		}
		transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
	}

	void FixedUpdate()
	{
		// Normal jump (full speed)
		if (jump)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jump = false;
		}
		// Cancel the jump when the button is no longer pressed
		if (jumpCancel)
		{
			if (rb.velocity.y > jumpShortSpeed)
				rb.velocity = new Vector2(rb.velocity.x, jumpShortSpeed);
			jumpCancel = false;
		}
		if (rb.velocity.y > 0) animator.SetFloat("VerticalDirection", 1f);
		else animator.SetFloat("VerticalDirection", -1f);
	}


	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.tag == "Ground")
		{
			canJump = true;
			animator.SetBool("onAir", false);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.collider.tag == "Ground")
		{
			canJump = false;
			animator.SetBool("onAir", true);
		}
	}

	public void StompJump()
	{
		rb.AddForce(Vector3.up * jumpShortSpeed, ForceMode2D.Impulse);
	}

	public void EmitHearts()
	{
		hearts.Emit(10);
	}

}
