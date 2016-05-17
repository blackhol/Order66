/* 7S_CROS_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public 	Sprite[] 	crosshair;
	public 	GameObject 	hpBar;
	public	Image		hpFill;

	private RaycastHit 	hit;
	private bool 		hitRange;

	[HideInInspector] public float range;

	void Update () {
		CheckRange ();
	}
		
	void CheckRange(){
		Transform camTransform = Camera.main.transform;

		if (Physics.Raycast (camTransform.position, camTransform.forward, out hit, range)) {
			if (hit.transform.parent != null && hit.transform.root.tag == "Enemy"){
				EnemyHealth enemyHealth = hit.transform.root.GetComponent<EnemyHealth>();
				hpFill.fillAmount = (enemyHealth.curHealth / enemyHealth.maxHealth);	

				hitRange = true;
			} else {
				hitRange = false;
			}
		} else {
			hitRange = false;
		}
		ShowCrosshair ();
		ShowHpBar ();
	}

	public void ShowHpBar(){		
		hpBar.SetActive (hitRange);
	}

	void ShowCrosshair(){
		if (hitRange) {
			gameObject.GetComponent<Image> ().sprite = crosshair [1];
		} else {
			gameObject.GetComponent<Image> ().sprite = crosshair [0];
		}
	}
}
