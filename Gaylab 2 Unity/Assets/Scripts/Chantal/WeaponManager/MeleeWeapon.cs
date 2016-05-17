/* 7S_CRCB_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class MeleeWeapon : WeaponManager {

	public override void OnEnable() {
		weaponHandler.weaponAttack = Attack;
		weaponHandler.aim = null;
		crosshair.range = range;
	}

	public override void Attack(){
		if (Input.GetButtonDown ("MeleeAttack")) {
			Transform camTransform = Camera.main.transform;
			if (Physics.Raycast (camTransform.position, camTransform.forward, out hit, range)) {
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
		}
	}
}
