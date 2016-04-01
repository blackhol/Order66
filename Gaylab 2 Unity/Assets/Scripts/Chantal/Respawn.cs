/* 7S_RESP_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	[HideInInspector] public Vector3 respawnPos;

	void Start () {
		respawnPos = transform.position;
	}

	public void RespawnPlayer () {
		transform.position = respawnPos;
	}
}
