/* 7S_RESP_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class PlayerSpawnPoint : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			col.GetComponent<PlayerRespawn> ().respawnPos = transform.position;
		}
	}
}
