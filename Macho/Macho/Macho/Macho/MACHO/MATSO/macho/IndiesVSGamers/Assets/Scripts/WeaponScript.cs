using UnityEngine;
using System.Collections;
using System;

public class WeaponScript : MonoBehaviour {

    public GameObject grenade;

	private Weapon me;

	private Transform barrel;
	private Vector3[] shotAngles;
	private GameObject bullet;
	private GameObject rocket;
	private Animator animator;
	
	private GameObject semiautobullet;
    private int shotsFired;
    private GameObject primaryGun;

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
		shotAngles = new Vector3[3] {Vector3.right, new Vector3(0.8f,0.8f,0).normalized , new Vector3(0.8f,-0.8f,0).normalized};

		//foreach (Transform t in transform)
		//{
		//	if (t.name == "Grenade") grenade = t.gameObject;
		//}
		foreach (Transform child in GameObject.FindWithTag("Player").transform)
		{
			if (child.name == "bullet")
				bullet = child.gameObject;
			else if (child.name == "rocket")
				rocket = child.gameObject;
			else if (child.name == "semiautobullet")
				semiautobullet = child.gameObject;
            else if (child.name == "Gun")
                primaryGun = child.gameObject;
		}

        animator = barrel.GetComponent<Animator>();
	}

    void OnEnable() {
        shotsFired = 0;
        StartCoroutine(ShootChecking());
    }

	IEnumerator ShootChecking() {
		while(true) {
			if (Input.GetButton("Fire1") && !PauseGame.isPaused) {
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
			else if (Input.GetButtonDown("Fire2") && Manager.Instance.grenades > 0 && !PauseGame.isPaused)
			{
				GameObject gr;
				gr = Instantiate(grenade, transform.position, transform.rotation) as GameObject;
				gr.SetActive(true);
				Manager.Instance.LoseGrenade();
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
					animator.SetTrigger("shoot");
					GameObject b = Instantiate(rocket, barrel.transform.position, transform.rotation * Quaternion.Euler(0,0,(i == 0)?(0):((i==1)?(25):(-25))) ) as GameObject;
					b.SetActive(true);
					b.GetComponent<RocketScript>().range = me.range;
                    shotsFired++;
                    Sounds.Instance.RocketLaucnher();
					yield return null;
				} while (hittarget && me.penetration );
                if (shotsFired >= me.clipsize && me.clipsize > 0) {
                    ItemManager.Instance.ActivateItem(primaryGun);
                }
				yield return null;
			}
			yield return null;
			break;
		case 0:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {  
					hittarget = false;
					animator.SetTrigger("shoot");
					RaycastHit2D hit = Physics2D.Raycast(barrel.position, transform.rotation *  shotAngles[i]  , (float)((me.range==0)?(5):((me.range==1)?(7):(15))));
					Debug.DrawRay(barrel.position, transform.rotation  * shotAngles[i] * (me.range + 1)*5 , Color.green, 0.3f);
					if (hit.transform != null) {
						if (hit.collider.tag == "Crate") hit.collider.transform.SendMessage("DropItem");
						if(hit.collider.tag == "Enemy") {
							hit.collider.transform.gameObject.GetComponent<EnemyScript>().Death();
							hittarget = true;
						}
					}
                    shotsFired++;
                    if (me.name == "Gun") {
                        Sounds.Instance.Gun();
                    } else if (me.name == "Shotgun") {
                        Sounds.Instance.Shotgun();
                    } else if (me.name == "Magnum") {
                        Sounds.Instance.Magnum();
                    }
                    yield return null;
				} while (hittarget && me.penetration );
				GameObject sab = Instantiate(semiautobullet, barrel.transform.position, transform.rotation * Quaternion.Euler(0, 0, (i == 0) ? (0) : ((i == 1) ? (25) : (-25)))) as GameObject;
				sab.SetActive(true);
				sab.GetComponent<BulletScript>().range = me.range;
                if (shotsFired >= me.clipsize && me.clipsize > 0) {
                    ItemManager.Instance.ActivateItem(primaryGun);
                }
				yield return null;
			}
			yield return null;

			break;
		case 1:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {
                    if (me.name == "AK47") Sounds.Instance.PlayAK47();
					hittarget = false;
					animator.SetBool("shooting", true);
					GameObject b = Instantiate(bullet, barrel.transform.position, transform.rotation * Quaternion.Euler(0,0,(i == 0)?(0):((i==1)?(25):(-25))) ) as GameObject;
					b.SetActive(true);
					b.GetComponent<BulletScript>().range = me.range;
                    shotsFired++;
					yield return null;
				} while (hittarget && me.penetration );
                if (me.name == "AK47") Sounds.Instance.StopAK47();
				animator.SetBool("shooting", false);
                if (shotsFired >= me.clipsize && me.clipsize > 0) {
                    ItemManager.Instance.ActivateItem(primaryGun);
                }
				yield return null;
			}
			yield return null;
			break;
		case 2:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {
                    if (me.name == "Minigun") Sounds.Instance.PlayMinigun();
					hittarget = false;
					animator.SetBool("shooting", true);
					GameObject b = Instantiate(bullet, barrel.transform.position, transform.rotation * Quaternion.Euler(0,0,(i == 0)?(0):((i==1)?(25):(-25))) ) as GameObject;
					b.SetActive(true);
					b.GetComponent<BulletScript>().range = me.range;
                    shotsFired++;
					yield return null;
				} while (hittarget && me.penetration );
                if (me.name == "Minigun") Sounds.Instance.StopMinigun();
				animator.SetBool("shooting", false);
                if (shotsFired >= me.clipsize && me.clipsize > 0) {
                    ItemManager.Instance.ActivateItem(primaryGun);
                }
				yield return null;
			}
			yield return null;
			break;
		case 3:
			for (int i = 0; i < Convert.ToInt32(me.spread)*2 + 1; ++i) { 
				bool hittarget;
				do {
                    if (me.name == "Lase") Sounds.Instance.PlayLaser();
					hittarget = false;
					animator.SetBool("shooting", true);
					RaycastHit2D hit = Physics2D.Raycast(barrel.position, transform.rotation *  shotAngles[i]  , (float)((me.range==0)?(5):((me.range==1)?(7):(15))));
					Debug.DrawRay(barrel.position, transform.rotation  * shotAngles[i] * (me.range + 1)*5 , Color.green, 0.3f);
					if (hit.transform != null) {
						if(hit.collider.tag == "Enemy") {
							hit.collider.transform.gameObject.GetComponent<EnemyScript>().Death();
							hittarget = true;
						}
						if (hit.collider.tag == "Crate") hit.collider.transform.SendMessage("DropItem");
					}
                    shotsFired++;
					yield return null;
				} while (hittarget && me.penetration );
                if (me.name == "Laser") Sounds.Instance.StopLaser();
				animator.SetBool("shooting", false);
                if (shotsFired >= me.clipsize && me.clipsize > 0) {
                    ItemManager.Instance.ActivateItem(primaryGun);
                }
				yield return null;
			}
			break;
		default:
			break;
		} 

	}

}
