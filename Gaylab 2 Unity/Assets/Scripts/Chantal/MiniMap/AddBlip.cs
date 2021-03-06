﻿/* 7S_MMAP_001
 * Made by: Chantal
 * MiniMap.cs + AddBlip.cs + Blip.cs
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddBlip : MonoBehaviour {

	public Transform blip;
	Transform blipList;

	void Start () {
		blipList = GameObject.Find ("BlipList").transform;
		Transform newBlip = Instantiate (blip) as Transform;
		newBlip.GetComponent<Blip> ().target = transform;
		newBlip.SetParent(blipList);
	}
}
