/* 7S_PICK_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	void OnCollisionStay(Collision col){
		if (Input.GetButtonDown ("Pickup")) {
			switch (col.transform.tag) {
				case "Ammo":
					PickupAmmo ();
					break;
				case "Hp":
					PickupHp ();
					break;
			}
		}
	}
		
	public void PickupAmmo(){
		//refill ammo
		print("ammo");
		//GetComponent<GunWeapon>().Reload ();

	}

	public void PickupHp(){
		//refill hp
		print("hp");
	}

}
