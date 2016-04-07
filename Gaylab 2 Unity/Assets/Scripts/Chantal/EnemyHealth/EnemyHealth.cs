using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 1;
	[HideInInspector] public float curHealth;
	private bool showHP = false;

	void Start () {
		curHealth = maxHealth;
	}
		
	public void CheckHealth(float dmg){
		showHP = true;
		if (curHealth - dmg <= 0) {
			Dead ();
		} else {
			curHealth -= dmg;
			print (curHealth);
		}
	}

	public void Dead(){
		//dead effects
		print("dead");
		Destroy(gameObject);
	}


}
