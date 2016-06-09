/* 7S_AMMO_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class AmmoRocket : MonoBehaviour {

	[HideInInspector] public float strength;
	[HideInInspector] public float range;
	public float speed = 2;
	public float sphereRadius = 1;
	private Vector3 startPos;
	Collider[] hitColliders;

	void Start(){
		startPos = transform.position;
	}

	void Update () {		
		Move ();
	}
		
	void Move(){
		if (Vector3.Distance (transform.position, startPos) < range && !Physics.Raycast (transform.position, transform.forward, 1)) {
			transform.Translate (Vector3.forward * speed);
		} else {
			//destroy effect
			Dmg ();
		}
	}
		
	void Dmg(){	
		hitColliders = Physics.OverlapSphere (transform.position, sphereRadius);	
		if (hitColliders != null){
			for (int i = 0; i < hitColliders.Length; i++){
				if (hitColliders [i].transform.root.tag == "Enemy") {
					EnemyHealth enemyHealthScr = hitColliders [i].transform.root.GetComponent<EnemyHealth> ();
					enemyHealthScr.CheckHealth (strength);
				} 
			}
		}
		Destroy (gameObject);
	}

//	void OnDrawGizmos(){
//		Gizmos.color = Color.magenta;
//		Gizmos.DrawWireSphere (transform.position, sphereRadius);
//	}

}
