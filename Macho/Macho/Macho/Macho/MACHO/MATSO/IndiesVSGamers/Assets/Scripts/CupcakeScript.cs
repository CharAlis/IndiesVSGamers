using UnityEngine;
using System.Collections;

public class CupcakeScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			Manager.Instance.LoseRazor();
		}
		else if (col.tag == "Ground") Destroy(this.gameObject);
	}
}
