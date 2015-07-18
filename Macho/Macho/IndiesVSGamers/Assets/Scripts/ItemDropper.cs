using UnityEngine;
using System.Collections;
using System;

public class ItemDropper : MonoBehaviour {

	private string name = null;

	void Update() {
		if(Input.GetKeyDown(KeyCode.F))
			DropItem();
	}

	void DropItem() {
		int x = (int)UnityEngine.Random.Range(1f,(float)Enum.GetNames(typeof(ItemIDs)).Length);
		name = ItemManager.Instance.items[((1/(float)x <= UnityEngine.Random.Range(0f , 1f)) ? ((int)UnityEngine.Random.Range(1f,(float)Enum.GetNames(typeof(ItemIDs)).Length)) : (x))].name;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if ( name == null )	DropItem();
		if (col.tag == "Player") 
			foreach (Transform child in GameObject.Find("Brockules").transform)
				if (child.name == name) 
					ItemManager.Instance.ActivateItem(child.gameObject);
		Destroy(gameObject);
	}
}