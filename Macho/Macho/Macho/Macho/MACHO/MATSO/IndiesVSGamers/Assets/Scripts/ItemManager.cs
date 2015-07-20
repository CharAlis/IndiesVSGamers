using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {
	public static ItemManager Instance;

	public List<Item> items;

	private GameObject currentItem = null;

	// Use this for initialization
	void Awake () {
		Instance = this;
		items = new List<Item>() {
			new Weapon((int)ItemIDs.Gun            , "Gun"            , 'w' , 1 , 0 , false , false,  -1 ),
			new Weapon((int)ItemIDs.Magnum         , "Magnum"         , 'w' , 2 , 0 , false , true ,   6 ),
			new Weapon((int)ItemIDs.Shotgun        , "Shotgun"        , 'w' , 0 , 0 , true  , false,  20 ),
			new Item  ((int)ItemIDs.Grenades       , "Granades"       , 'g' ),
			new Item  ((int)ItemIDs.Razor          , "Razor"          , 'r' ),
			new Weapon((int)ItemIDs.AK47           , "AK47"           , 'w' , 2 , 1 , false , false,  30 ),
			new Weapon((int)ItemIDs.Laser          , "Laser"          , 'w' , 2 , 3 , false , true,  400 ),
			new Weapon((int)ItemIDs.Rocketlauncher , "Rocketlauncher" , 'w' , 2 ,-1 , false , false,   3 ),
			new Weapon((int)ItemIDs.Minigun        , "Minigun"        , 'w' , 2 , 2 , true  , false, 200 )
		};

		foreach (Transform child in GameObject.Find("Brockules").transform)
			if (child.name == "Gun") 
				ActivateItem(child.gameObject);
	}

	public void ActivateItem(GameObject item) {
		Item pickedItem = null;
		foreach (Item i in items) {
			if (i.name == item.name) pickedItem = i;
		}
		if (pickedItem == null) return;
		if (pickedItem.type == 'w' && currentItem != null) currentItem.SetActive(false);
		if (pickedItem.type == 'w') currentItem = item;
		else if (pickedItem.type == 'r') Manager.Instance.GetRazor();
		else if (pickedItem.type == 'g') Manager.Instance.GetGrenade();
		item.SetActive(true);
	}

}
