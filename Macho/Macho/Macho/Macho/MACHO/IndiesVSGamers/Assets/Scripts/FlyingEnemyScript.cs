using UnityEngine;
using System.Collections;

public class FlyingEnemyScript : MonoBehaviour {

    public float maxHeight = 9f;
    public float minHeight = 7f;

    private Transform player;
    private Animator animator;
    private Collider2D[] colliders;

    //private ParticleSystem cotton;    //particles for death

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        colliders = GetComponents<Collider2D>();

        //cotton = transform.FindChild("Cotton").GetComponent<ParticleSystem>();
    }

    void Update() {
        transform.Translate(Vector3.left * 5 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minHeight, maxHeight, transform.position.y)); //DOES NOT WORK DAMMIT

        if (Mathf.Approximately(player.position.x, transform.position.x)) {
            Bombing();
        }
    }

    void Bombing() {
        GameObject bomb = Instantiate(transform.FindChild("bomb"), transform.position, Quaternion.Euler(new Vector3(player.position.x - transform.position.x + Random.Range(-5f, 5f), player.position.y - transform.position.y + Random.Range(-5f, 5f), 0f))) as GameObject;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            Manager.Instance.LoseRazor();
            foreach (Collider2D c in colliders) c.enabled = false;
        }
    }

    public void DestroyEnemy() {
        Manager.Instance.AddScore(30);
        CameraShakeScript.Instance.Shake(0.05f, 0.1f);
        Destroy(this.gameObject);
    }

    public void Death() {
        transform.SetParent(null);
        animator.SetBool("Death", true);
        // cotton.Emit(30);
    }
}