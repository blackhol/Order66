/* 7S_UIME_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public enum Menutabs {
		StartPage,
		Difficulty,
		Pause,
		SoundOptions,
		GraphicOptions,
		KeySettingOptions,
		Gameplay
	};

	public Menutabs menutabs;
	public GameObject[] menuObjects;
	public GameObject startPageObject;
	public GameObject optionsObject;

	private bool inPause = false;

	void Start(){
		Time.timeScale = 0;
		SetMenu (0);
	}

	void Update(){
		Pause ();
	}

	public void ChangeTab(int id){
		menutabs = (Menutabs)id;
		CheckTab ();
	}

	void CheckTab(){
		switch (menutabs) {
			case Menutabs.StartPage:
				SetMenu (0);
				break;
			case Menutabs.Difficulty:
				SetMenu (1);
				break;
			case Menutabs.Pause:
				SetMenu (2);
				break;
			case Menutabs.SoundOptions:
				SetMenu (3);
				break;
			case Menutabs.GraphicOptions:
				SetMenu (4);
				break;
			case Menutabs.KeySettingOptions:
				SetMenu (5);
				break;
			case Menutabs.Gameplay:
				SetMenu (6);
				Time.timeScale = 1;
				inPause = false;
				break;
		}
	}

	void SetMenu(int num){
		for (int i = 0; i < menuObjects.Length; i++) {
			menuObjects [i].SetActive (false);
		}
		startPageObject.SetActive (false);
		optionsObject.SetActive (false);

		if (num <= 1) {
			startPageObject.SetActive (true);
		} else if (num >= 3 && num <= 5) {
			optionsObject.SetActive (true);
		} 

		if (num < 6) {
			menuObjects [num].SetActive (true);
		}
	}

	void Pause(){
		if (Input.GetButtonDown("Pause")){
			if (inPause) {
				menutabs = Menutabs.Gameplay;
				inPause = false;
				Time.timeScale = 1;
			} else {
				menutabs = Menutabs.Pause;
				inPause = true;
				Time.timeScale = 0;
			}

			CheckTab ();
		}
	}

	public void StartGame(int difficulty){		
		switch (difficulty) {
		//ignore case 1 & 2 if no difficulty mode is coded
			case 0: //normal
			//start normal level game
				break;
			case 1: //hard
			//start hard level game
				break;
			case 2: //very hard
			//start very hard level game
				break;
		}
		ChangeTab (6);
		Time.timeScale = 1;
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
