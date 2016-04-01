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
				if (hit.transform.tag == "Enemy") {
					print ("hit an enemy!!");
				}
			}
		}
	}
}
