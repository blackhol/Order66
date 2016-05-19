/* 7S_MMAP_001
 * Made by: Chantal
 * MiniMap.cs + AddBlip.cs + Blip.cs
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniMap : MonoBehaviour {

	public Transform target;
	public float zoomLevel = 10;
	public Vector2 zoomLock = new Vector2 (1, 10);
	public Transform canvas;
	public Slider zoomBar;
	public Transform mapButton;
	public Sprite[] mapBtImg;
	private Rect miniMapRect;
	private RectTransform thisRt;
	private bool fullmap = false;
	private Rect canvasRect;

	void Start(){
		zoomBar.minValue = zoomLock.x;
		zoomBar.maxValue = zoomLock.y;
		zoomBar.value = zoomLevel;
		canvasRect = canvas.GetComponent<RectTransform> ().rect;
		thisRt = gameObject.GetComponent<RectTransform> ();
		miniMapRect = thisRt.rect;
		miniMapRect.position = (miniMapRect.position - canvasRect.position) * -1;
	}

	public Vector2 TransformPosition (Vector3 position){
		Vector3 offset = position - target.position;
		Vector2 newPosition = new Vector2 (offset.x, offset.z);
		zoomLevel = Mathf.Clamp (zoomLevel, zoomLock.x, zoomLock.y);
		newPosition *= zoomLevel;

		return newPosition;
	}

	void Update (){
		if (Input.GetButtonDown ("Map")) {	
			MapSize ();
		}
	}

	public void MapSize(){			
		if (!fullmap) {
			thisRt.sizeDelta = canvasRect.size;
			thisRt.localPosition = new Vector2 (0, 0);
			mapButton.GetComponent<Image> ().sprite = mapBtImg [1];
			Vector3 bigSize = new Vector3 (2, 2, 1);
			zoomBar.transform.localScale = bigSize;
			mapButton.localScale = bigSize;
			fullmap = true;
		} else {
			thisRt.sizeDelta = miniMapRect.size;
			thisRt.localPosition = miniMapRect.position;
			mapButton.GetComponent<Image> ().sprite = mapBtImg [0];
			Vector3 smallSize = new Vector3 (1, 1, 1);
			zoomBar.transform.localScale = smallSize;
			mapButton.localScale = smallSize;
			fullmap = false;
		}	
	}

	public void ZoomBar(){
		zoomLevel = zoomBar.value;
	}

	public void MapButton(){
		MapSize ();
	}

}
