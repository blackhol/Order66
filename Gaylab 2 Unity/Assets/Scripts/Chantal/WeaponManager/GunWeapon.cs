/* 7S_CRCB_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class GunWeapon : GunManager {
	void Start (){
		curAmmo = maxAmmo;
	}

	public override void OnEnable() {
		weaponHandler.weaponAttack = Attack;
		weaponHandler.aim = Aiming;
		crosshair.range = range;
	}

	public override void Attack(){
		if (Input.GetButtonDown ("Fire1")) {
			if (curAmmo >= useAmmo && mayAttack) {
				curAmmo--;
				Transform camTransform = Camera.main.transform;
				if (Physics.Raycast (camTransform.position, camTransform.forward, out hit, range)) {
					if (hit.transform.parent.tag == "Enemy") {
						EnemyHealth enemyHealthScr = hit.transform.parent.GetComponent<EnemyHealth> ();
						switch (hit.transform.tag) {
							case "Head":
								enemyHealthScr.CheckHealth (strength * 3);
								break;
							case "Body":
								enemyHealthScr.CheckHealth (strength * 2);
								break;
							case "Legs":
								enemyHealthScr.CheckHealth (strength * 1);
								break;
							case "Wings":
								enemyHealthScr.CheckHealth (strength * 1);
								break;
							default:
								print ("enemy is missing tags");
								break;
						}
					}
				}
				StartCoroutine(AttackCoolDown());
			} else {
				print ("Not enough ammo or may not shoot yet");
			}
		}
	}

	public override void Aiming(){
		if (Input.GetButton ("Fire2")) {
			camera.fieldOfView = aimZoomin;
		} else {
			camera.fieldOfView = aimZoomOut;
		}
	}

	public override void Reload(){
		curAmmo = maxAmmo;
	}

	public override IEnumerator AttackCoolDown (){
		mayAttack = false;
		yield return new WaitForSeconds(coolDown);
		mayAttack = true;
	}

}
