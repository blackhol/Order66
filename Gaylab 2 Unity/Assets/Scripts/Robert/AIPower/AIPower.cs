using UnityEngine;
using System.Collections;

public class AIPower : MonoBehaviour {
	public int baseDamage;
	public int maxDamage;
	public int calculatetDamage;

	void DoDamage (Transform enemy){
		//grab the oponent CalculateDamage() - hp;
	}
	int CalculateDamage () {
		calculatetDamage = Random.Range(baseDamage,maxDamage);
		return calculatetDamage;
	}
}
