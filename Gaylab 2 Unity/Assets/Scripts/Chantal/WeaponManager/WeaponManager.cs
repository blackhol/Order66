using UnityEngine;
using System.Collections;

public abstract class WeaponManager : MonoBehaviour {

	public float strength = 1;
	public float range = 1;
	public float coolDown;
	public bool mayAttack = true;
	public WeaponHandler weaponHandler;
	public RaycastHit hit;

	public abstract void Attack();
	public abstract void OnEnable ();

}
