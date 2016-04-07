/* 7S_CRCB_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class MeleeWeapon : WeaponManager {

	public override void OnEnable() {
		weaponHandler.weaponAttack = Attack;
	}

	public override void Attack(){
		if (Input.GetButtonDown ("MeleeAttack")) {
			var camTransform = Camera.main.transform;
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
		}
	}
}
