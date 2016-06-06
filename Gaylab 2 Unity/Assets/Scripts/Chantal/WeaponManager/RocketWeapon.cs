/* 7S_CRCB_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class RocketWeapon : GunManager {

	public GameObject rocket;
	public Transform rocketSpawn;

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

				GameObject newRocket = Instantiate (rocket, rocketSpawn.position, transform.rotation) as GameObject;
				newRocket.GetComponent<AmmoRocket> ().strength = strength;
				newRocket.GetComponent<AmmoRocket> ().range = range;

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
