using UnityEngine;
using System.Collections;

public class ShadowyBehaviour : MonoBehaviour {

    private Transform player;
    private SpriteRenderer renderer;
    private float defY;
    private float jumpStartPos;
    private Vector3 startingScale;

    public static ShadowyBehaviour Instance;

	// Use this for initialization
	void Awake () {
        Instance = this;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        renderer = gameObject.GetComponent<SpriteRenderer>();

        transform.position = new Vector3(player.position.x, player.position.y - 1, transform.position.z);

        jumpStartPos = 0;
        startingScale = transform.localScale;
	}
	
	// Update is called once per frame
	void LateUpdate () {
       // transform.position.x = player.position.x;
        Vector3 newPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = newPos;

        if (Brockontroller.Instance.canJump) {
            transform.localScale = startingScale;
        } else {
            transform.localScale = Vector3.one * (2 / (jumpStartPos - player.position.y)) * startingScale.x;
        }
	}

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ground") {
            renderer.color = new Color(0f, 0f, 0f, 0f);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Ground") {
            renderer.color = new Color(0f, 0f, 0f, 0.8f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            renderer.color = new Color(0f, 0f, 0f, 0.8f);
            transform.position = new Vector3(transform.position.x, other.bounds.center.y + 4.45f, transform.position.z);
        }
    }

    void SavePosScale() {
        jumpStartPos = player.position.y;
        startingScale = transform.localScale;
    }
}
