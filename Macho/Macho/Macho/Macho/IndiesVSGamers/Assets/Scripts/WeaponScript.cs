using UnityEngine;
using System.Collections;
using System;

public class WeaponScript : MonoBehaviour {

	private Weapon me;

	private Transform barrel;
	private Vector3[] shotAngles;
	private GameObject bullet;
	private GameObject rocket;

	void Awake() {
		foreach ( Item item in ItemManager.Instance.items ) {
			if (item.name == this.transform.name) {
				me = item as Weapon;
			}
		}
		foreach (Transform child in transform) {
			if (child.name == "barrel") 
				barrel = child;
		}

		shotAngles = new Vector3[3] {Vector3.right, new Vector3(1,1,0).normalized , new Vector3(1,-1,0).normalized};

		foreach (Transform child in GameObject.FindWithTag("Player").transform) {
			if (child.name == "bullet") 
				bullet = child.gameObject;
			else if (child.name == "rocket") 
				rocket = child.gameObject;
		}


	}

	void Start() {
		StartCoroutine(ShootChecking());
	}

	IEnumerator ShootChecking() {
		while(true) {
			if (Input.GetButton("Fire1")) {
				if (Input.GetButtonDown("Fire1") && me.firerate == 0) {
					StartCoroutine(Fire ());
					yield return new WaitForSeconds(0.3f);
				} else if (me.firerate == 1 ) {
					StartCoroutine(Fire ());
					yield return new WaitForSeconds(0.15f);
				} else if (me.firerate == 2) {
					StartCoroutine(Fire ());
					yield return new WaitForSeconds(0.10f);
				} else if (me.firerate == 3) {
					StartCoroutine(Fire ());
					yield return null;
				} else if (me.firerate == -1) {
					StartCoroutine(Fire ());
					yield return new WaitForSeconds(0.5f);
				}
				yield return null;
			}
			yield return null;
		}
		yield return null;
	}

	IEnumerator Fire() {
		switch (me.firerate) {
		case -1:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {  
					hittarget = false;
					GameObject b = Instantiate(rocket, barrel.transform.position, transform.rotation * Quaternion.Euler(0,0,(i == 0)?(0):((i==1)?(25):(-25))) ) as GameObject;
					b.SetActive(true);
					b.GetComponent<BulletScript>().range = me.range;
					yield return null;
				} while (hittarget && me.penetration ); 
				yield return null;
			}
			yield return null;
			break;
		case 0:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {  
					hittarget = false;
					RaycastHit2D hit = Physics2D.Raycast(barrel.position, transform.rotation *  shotAngles[i]  , (float)((me.range==0)?(5):((me.range==1)?(7):(15))));
					Debug.DrawRay(barrel.position, transform.rotation  * shotAngles[i] * (me.range + 1)*5 , Color.green, 0.3f);
					if (hit.transform != null) {
						if(hit.collider.tag == "Enemy") {
							hit.collider.transform.gameObject.GetComponent<EnemyScript>().DestroyEnemy();
							hittarget = true;
						}
					}
					yield return null;

				} while (hittarget && me.penetration ); 
				yield return null;
			}
			yield return null;

			break;
		case 1:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {  
					hittarget = false;
					GameObject b = Instantiate(bullet, barrel.transform.position, transform.rotation * Quaternion.Euler(0,0,(i == 0)?(0):((i==1)?(25):(-25))) ) as GameObject;
					b.SetActive(true);
					b.GetComponent<BulletScript>().range = me.range;
					yield return null;
				} while (hittarget && me.penetration ); 
				yield return null;
			}
			yield return null;
			break;
		case 2:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {  
					hittarget = false;
					GameObject b = Instantiate(bullet, barrel.transform.position, transform.rotation * Quaternion.Euler(0,0,(i == 0)?(0):((i==1)?(25):(-25))) ) as GameObject;
					b.SetActive(true);
					b.GetComponent<BulletScript>().range = me.range;
					yield return null;
				} while (hittarget && me.penetration ); 
				yield return null;
			}
			yield return null;
			break;
		case 3:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {  
					hittarget = false;
					RaycastHit2D hit = Physics2D.Raycast(barrel.position, transform.rotation *  shotAngles[i]  , (float)((me.range==0)?(5):((me.range==1)?(7):(15))));
					Debug.DrawRay(barrel.position, transform.rotation  * shotAngles[i] * (me.range + 1)*5 , Color.green, 0.3f);
					if (hit.transform != null) {
						if(hit.collider.tag == "Enemy") {
							hit.collider.transform.gameObject.GetComponent<EnemyScript>().DestroyEnemy();
							hittarget = true;
						}
					}
					yield return null;
					
				} while (hittarget && me.penetration ); 
				yield return null;
			}
			break;
		default:
			break;
		} 

	}

}
