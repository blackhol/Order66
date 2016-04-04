/* 7S_PICK_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {

	public List<GameObject> rocketWeapons = new List<GameObject> ();
	public List<GameObject> gunWeapons = new List<GameObject> ();

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
					PickupHp ();
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
			rocketWeapons[i].GetComponent<RocketWeapon>().Reload ();
		}
	}

	public void PickupHp(){
		//refill hp
		print("hp");
	}

}
