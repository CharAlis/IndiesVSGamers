using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour
{
    public GameObject grenade;
    public float radius = 3.0f;
    public float force = 7.0f;

    private Vector2 grenadeOrigin;

	void Update () 
    {
	    if (Input.GetButton("Fire2"))
        {
            StartCoroutine("Explode");
        }
	}

    IEnumerator Explode()
    {
        Instantiate(grenade, transform.position, transform.rotation);
        grenadeOrigin = transform.position;
        Collider2D[] cols = Physics2D.OverlapCircleAll(grenadeOrigin, radius);

        foreach(Collider2D hit in cols)
        {
			if (hit.tag == "Enemy") hit.transform.GetComponent<EnemyScript>().Death();
        }

        new WaitForSeconds(0.6f);
        Destroy(gameObject);
        yield return null;
    }
}
