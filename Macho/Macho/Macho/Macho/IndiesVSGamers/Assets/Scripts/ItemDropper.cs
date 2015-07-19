using UnityEngine;
using System.Collections;
using System;

public class ItemDropper : MonoBehaviour {

	private string name = null;
	private Transform boxParticles;

	void Awake()
	{
		boxParticles = transform.FindChild("BoxParticles");
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.F))
			DropItem();
	}

	void DropItem() {
		int x = (int)UnityEngine.Random.Range(1f,(float)Enum.GetNames(typeof(ItemIDs)).Length);
		name = ItemManager.Instance.items[((1/(float)x <= UnityEngine.Random.Range(0f , 1f)) ? ((int)UnityEngine.Random.Range(1f,(float)Enum.GetNames(typeof(ItemIDs)).Length)) : (x))].name;
		foreach (Transform t in boxParticles)
		{
			t.GetComponent<ParticleSystem>().Emit(10);
		}
		foreach(Transform t in transform)
		{
			if (t.name == name) t.GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player" || col.tag == "Bullet")
		{
			if (name == null) DropItem();
			foreach (Transform child in GameObject.Find("Brockules").transform)
				if (child.name == name)
					ItemManager.Instance.ActivateItem(child.gameObject);
			foreach(Transform t in transform)
			{
				if (t.GetComponent<SpriteRenderer>() != null) t.GetComponent<SpriteRenderer>().enabled = false;
			}
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
