using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	public GunWeapon gunWeaon;
	public RocketWeapon rocketWeapon;
	public MeleeWeapon meleeWeapon;
	public CharController charController;
	[HideInInspector] public int upgradePoint;

	int[] upgradeCount = new int[4];

	void Start(){
		upgradeCount [0] = 2;
		GunUpgrade ();
	}

	public void GunUpgrade(){
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
				//disable ability to choose this upgrade
				break;
		}
		upgradePoint--;
		upgradeCount [0]++;
	}

	public void RocketUpgrade(){
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
				//disable ability to choose this upgrade
				break;
		}
		upgradePoint--;
		upgradeCount [1]++;
	}

	public void SwordUpgrade(){
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
			//disable ability to choose this upgrade
			break;
		}
		upgradePoint--;
		upgradeCount [2]++;
	}

	public void MobilityUpgrade(){
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
			charController.dashDmg += 10;
			//disable ability to choose this upgrade
			break;
		}
		upgradePoint--;
		upgradeCount [3]++;
	}
}
