/* 7S_MMAP_001
 * Made by: Chantal
 * MiniMap.cs + AddBlip.cs + blip.cs
 */ 

using UnityEngine;
using System.Collections;

public class Blip : MonoBehaviour {

	public Transform target;
	public bool lockScale = false;
	public bool lockRotation = true;

	MiniMap map;
	RectTransform myRectTransform;

	void Start () {
		map = GetComponentInParent<MiniMap> ();
		myRectTransform = GetComponent<RectTransform> ();
	}
		

	void LateUpdate(){
		if (target == null) {
			Destroy (gameObject);
		} else {
			Vector2 newPosition = map.TransformPosition (target.position);
			myRectTransform.localPosition = newPosition;

			if (!lockScale) {
				myRectTransform.localScale = new Vector3 (map.zoomLevel, map.zoomLevel, 1);
			}

			if (!lockRotation) {
				myRectTransform.eulerAngles = new Vector3 (0, 0, -target.eulerAngles.y);
			}
		}
	}

}
