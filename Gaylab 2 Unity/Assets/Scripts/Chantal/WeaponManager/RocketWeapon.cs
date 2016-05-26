/* 7S_CRCB_001 
 * Made by: Chantal
 */ 


using UnityEngine;
using System.Collections;

public class RocketWeapon : GunManager {
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
				if (Physics.Raycast (camTransform.position, camTransform.forward, out hit, range)) {
					if (hit.transform.root.tag == "Enemy") {
						print ("Shot an enemy!!");
						//spawn rocket
							//rocket do dmg
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
