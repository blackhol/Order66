using UnityEngine;
using System.Collections;

public abstract class GunManager : WeaponManager {

	public int maxAmmo = 10;
	[HideInInspector] public int curAmmo;
	public int useAmmo = 1;
	public float aimZoomin = 30;
	public float aimZoomOut = 60;
	public Camera camera;

	public override void Attack(){
	}

	public override void OnEnable(){
	}

	public abstract void Aiming();

	public abstract void Reload();

	public abstract IEnumerator AttackCoolDown ();

}
