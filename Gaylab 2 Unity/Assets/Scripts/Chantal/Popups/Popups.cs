/* 7S_HUDP_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popups : MonoBehaviour {
	public GameObject popup;
	public Text popupTextField;
	public string[] popupText;
	public float visibleTime;

	public void SetText (int textId){
		if (textId < popupText.Length) {
			popupTextField.text = popupText [textId];
			StartCoroutine(VisiblePopup ());
		} else {
			print ("This ID gives an error, ID: "+ textId);
		}
	}

	public void ClosePopup(){
		popup.SetActive (false);
	}

	public IEnumerator VisiblePopup(){
		popup.SetActive (true);
		yield return StartCoroutine(WaitForRealSeconds(visibleTime));
		popup.SetActive (false);
	}

	public static IEnumerator WaitForRealSeconds(float delay){ 
	//to ignore timescale
		float start = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup < start + delay){
			yield return null;
		}
	}
}
