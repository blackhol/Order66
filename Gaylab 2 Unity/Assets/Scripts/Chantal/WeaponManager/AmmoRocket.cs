/* 7S_AMMO_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class AmmoRocket : MonoBehaviour {

	[HideInInspector] public float strength;
	[HideInInspector] public float range;
	public float speed;
	public float sphereRadius;
	private Vector3 startPos;
	Collider[] hitColliders;

	void Start(){
		startPos = transform.position;
	}

	void Update () {
		hitColliders = Physics.OverlapSphere (transform.position, sphereRadius);
		Move ();
	}

	void Move(){
		if (Vector3.Distance (transform.position, startPos) < range) {
			transform.Translate (Vector3.forward * speed);
		} else {
			//destroy effect
			Dmg ();
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision coll){
//		if (coll.transform.root.tag == "Enemy") {
//			//on hit enemy do radius dmg
//			print ("testworks");
//		} 
//		Dmg ();
	}

	void Dmg(){
		for (int i = 0; i < hitColliders.Length; i++) {
			if (hitColliders [i].transform.root.tag == "Enemy") {
				print ("enemy");
				EnemyHealth enemyHealthScr = hitColliders [i].transform.root.GetComponent<EnemyHealth> ();
				enemyHealthScr.CheckHealth (strength);
			} else {
				print ("something else " + hitColliders[i].name);
			}
			print ("i = " +i +" / hitColliders length:" + hitColliders.Length);
		}

	}

}
