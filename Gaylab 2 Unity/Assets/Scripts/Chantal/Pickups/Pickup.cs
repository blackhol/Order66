/* 7S_PICK_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {

	public List<GameObject> rocketWeapons = new List<GameObject> ();
	public List<GameObject> gunWeapons = new List<GameObject> ();
	public ShieldAndHealth shieldAndHealthScr;

	void OnCollisionStay(Collision col){
		if (Input.GetButtonDown ("Pickup")) {
			switch (col.transform.tag) {
				case "AmmoGun":
					PickupGunAmmo ();
					break;
				case "AmmoRocket":
					PickupRocketAmmo ();
					break;
				case "Hp":
					PickupHp (col.gameObject.GetComponent<HealthPickup>().healAmount);
					break;
			}
		}
	}
		
	public void PickupGunAmmo(){
		for (int i = 0; i < rocketWeapons.Count; i++) {
			gunWeapons[i].GetComponent<GunWeapon>().Reload ();
		}

	}

	public void PickupRocketAmmo(){
		for (int i = 0; i < rocketWeapons.Count; i++) {
			rocketWeapons[i].GetComponent<GunWeapon>().Reload ();
		}
	}

	public void PickupHp(float heal){
		if (shieldAndHealthScr.curHealth + heal <= shieldAndHealthScr.maxHealth) {
			shieldAndHealthScr.curHealth += heal;
		} else {
			shieldAndHealthScr.curHealth = shieldAndHealthScr.maxHealth;
		}
	}

}
