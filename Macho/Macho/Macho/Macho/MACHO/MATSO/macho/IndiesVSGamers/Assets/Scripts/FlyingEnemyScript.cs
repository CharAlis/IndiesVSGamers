using UnityEngine;
using System.Collections;

public class FlyingEnemyScript : MonoBehaviour {

    public float maxHeight = 9f;
    public float minHeight = 7f;

    private Transform player, scanner, bomb;
    private Animator animator;
    private Collider2D collider;

    //private ParticleSystem cotton;    //particles for death

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
		scanner = transform.FindChild("Scanner");
		bomb = transform.FindChild("bomb");

        //cotton = transform.FindChild("Cotton").GetComponent<ParticleSystem>();
    }

    void Update() {
        transform.Translate(Vector3.left * (MovingPlatform.Instance.speed + 3) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minHeight, maxHeight, transform.position.y)); //DOES NOT WORK DAMMIT
		RaycastHit2D hit = Physics2D.Raycast(scanner.position, Vector2.down);
		Debug.DrawRay(scanner.position, Vector3.down, Color.green);
		if (hit.collider != null)
		{
			if (hit.collider.tag == "Player")	bomb.GetComponent<Rigidbody2D>().isKinematic = false;
		}
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            collider.enabled = false;
        }
    }
}
