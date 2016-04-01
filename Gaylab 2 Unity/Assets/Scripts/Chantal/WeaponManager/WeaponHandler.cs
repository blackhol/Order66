using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponHandler : MonoBehaviour {

	public delegate void WeaponAttackDel();
	public WeaponAttackDel weaponAttack;
	public delegate void AimDel();
	public AimDel aim;

	public List<GameObject> weapons = new List<GameObject> ();
	public GameObject meleeWeapon;
	private int selectedWeapon;
	private bool swordActivated = false;

	void Start (){
		WeaponSwitch ();
	}

	void Update () {
		MeleeSwitch();
		WeaponSelect ();
		weaponAttack();

		if (aim != null) {
			aim ();
		}
	}

	void MeleeSwitch(){
		if (Input.GetButtonDown ("MeleeAttack") && swordActivated == false) {
			swordActivated = true;
			meleeWeapon.SetActive (true);
			weapons [selectedWeapon].SetActive(false);
		}

		if (Input.GetButtonDown ("Fire1") && swordActivated == true) {
			swordActivated = false;
			meleeWeapon.SetActive (false);
			weapons [selectedWeapon].SetActive(true);
		}
	}

	void WeaponSelect(){
		if (swordActivated == false) {
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				if (selectedWeapon == 0) {
					selectedWeapon = weapons.Count - 1;
				} else {
					selectedWeapon--;
				}
				WeaponSwitch ();
			} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				if (selectedWeapon == weapons.Count - 1) {
					selectedWeapon = 0;
				} else {
					selectedWeapon++;
				}
				WeaponSwitch ();
			}
		}
	}

	void WeaponSwitch(){
		for (int i = 0; i < weapons.Count; i++) {
			weapons [i].SetActive(false);
		}

		weapons [selectedWeapon].SetActive(true);
	}
}
