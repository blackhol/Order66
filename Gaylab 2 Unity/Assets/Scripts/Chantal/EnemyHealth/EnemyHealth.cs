/* 7S_AIHP_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 5;
	[HideInInspector] public float 	curHealth;

	void Start () {
		curHealth = maxHealth;
	}

	public void CheckHealth(float dmg){		
		if (curHealth - dmg <= 0) {
			curHealth = 0;
			Dead ();
		} else {
			curHealth -= dmg;
		}
	}

	public void Dead(){
		//dead effects
		float deadAnimationLength = 3 +0.5f;
		Destroy(gameObject, deadAnimationLength);
	}
}
