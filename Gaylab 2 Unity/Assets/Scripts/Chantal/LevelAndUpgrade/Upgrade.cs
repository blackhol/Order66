﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {
	public GunWeapon gunWeaon;
	public RocketWeapon rocketWeapon;
	public MeleeWeapon meleeWeapon;
	public CharController charController;
	public Text[] upgradeLevelTxt;
	public Text upgradePointTxt;
	public GameObject[] upgradeBts;
	public float upgradedDashDmg = 5;
	[HideInInspector] public int upgradePoint;

	int[] upgradeCount = new int[4];

	void OnEnable(){
		UpgradeAvaiability ();
	}

	void Start(){
		upgradePointTxt.text = "Upgrade Points: " + upgradePoint;
	}

	public void AddPoints(){
		upgradePoint++;
		upgradePointTxt.text = "Upgrade Points: " + upgradePoint;
	}

	public void GunUpgrade(){
		if (upgradePoint > 0) {
			switch (upgradeCount [0]) {
			case 0: 
				gunWeaon.coolDown *= 1.25f;
				break;
			case 1: 
				gunWeaon.strength *= 1.20f;
				gunWeaon.maxAmmo += (int)(gunWeaon.maxAmmo * 0.25);
				gunWeaon.curAmmo = gunWeaon.maxAmmo;
				break;
			case 2: 
				gunWeaon.coolDown = 0;
				gunWeaon.maxAmmo += (int)(gunWeaon.maxAmmo * 0.5);
				gunWeaon.curAmmo = gunWeaon.maxAmmo;
				break;
			}
			upgradePoint--;
			upgradeCount [0]++;
			upgradeLevelTxt [0].text = upgradeCount [0] + "/3";
			upgradePointTxt.text = "Upgrade Points: " + upgradePoint;
			UpgradeAvaiability ();
		}
	}

	public void RocketUpgrade(){
		if (upgradePoint > 0) {
			switch (upgradeCount [1]) {
			case 0: 
				rocketWeapon.strength *= 1.25f;
				break;
			case 1: 
				rocketWeapon.coolDown *= 1.20f;
				rocketWeapon.maxAmmo += (int)(rocketWeapon.maxAmmo * 0.20);
				rocketWeapon.curAmmo = rocketWeapon.maxAmmo;
				break;
			case 2:
				rocketWeapon.strength *= 1.50f;
				rocketWeapon.maxAmmo += (int)(rocketWeapon.maxAmmo * 0.25);
				rocketWeapon.curAmmo = rocketWeapon.maxAmmo;
				break;
			}
			upgradePoint--;
			upgradeCount [1]++;
			upgradeLevelTxt [1].text = upgradeCount [1] + "/3";
			upgradePointTxt.text = "Upgrade Points: " + upgradePoint;
			UpgradeAvaiability ();
		}
	}

	public void SwordUpgrade(){
		if (upgradePoint > 0) {
			switch (upgradeCount [2]) {
			case 0: 
				rocketWeapon.coolDown = 0;
				break;
			case 1: 
				rocketWeapon.strength *= 1.50f;
				break;
			case 2: 
				rocketWeapon.strength *= 1.50f;
				rocketWeapon.range *= 1.25f;
				break;
			}
			upgradePoint--;
			upgradeCount [2]++;
			upgradeLevelTxt [2].text = upgradeCount [2] + "/3";
			upgradePointTxt.text = "Upgrade Points: " + upgradePoint;
			UpgradeAvaiability ();
		}
	}

	public void MobilityUpgrade(){
		if (upgradePoint > 0) {
			switch (upgradeCount [3]) {
			case 0: 
				charController.canJump = true;
				break;
			case 1: 
				charController.walkSpeed *= 1.25f;
				charController.dashSpeed *= 1.25f;
				charController.dashDistrance *= 1.25f;
				break;
			case 2: 
				charController.dashDmg += upgradedDashDmg;
				break;
			}
			upgradePoint--;
			upgradeCount [3]++;
			upgradeLevelTxt [3].text = upgradeCount [3] + "/3";
			upgradePointTxt.text = "Upgrade Points: " + upgradePoint;
			UpgradeAvaiability ();
		}
	}

	void UpgradeAvaiability(){
		for (int i = 0; i < upgradeBts.Length; i++){
			upgradeBts[i].GetComponent<Button> ().interactable = false;
		}

		if (upgradePoint > 0){
			for (int j = 0; j < upgradeBts.Length; j++){
				if (upgradeCount [j] <= 2) {
					upgradeBts [j].GetComponent<Button> ().interactable = true;
				}
			}
		}
	}
}
