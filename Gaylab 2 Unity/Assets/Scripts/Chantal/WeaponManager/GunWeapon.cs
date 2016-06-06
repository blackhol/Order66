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
		if (Input.GetButtonDown ("Fire1") && menu.menutabs == Menu.Menutabs.Gameplay) {
			if (curAmmo >= useAmmo && mayAttack) {
				curAmmo--;
				Transform camTransform = Camera.main.transform;
				Vector3 tarPoint = camTransform.position;
				tarPoint.y += 1;

				if (Physics.Raycast (tarPoint, camTransform.forward, out hit, range)) {
					//Debug.DrawRay (tarPoint, camTransform.forward * 2000, Color.magenta);
					if (hit.transform.root.tag == "Enemy") {
						EnemyHealth enemyHealthScr = hit.transform.root.GetComponent<EnemyHealth> ();
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
