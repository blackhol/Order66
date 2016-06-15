/* 7S_UIME_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public enum Menutabs {
		StartPage,			//0
		Difficulty,			//1
		Pause,				//2
		SoundOptions,		//3
		GraphicOptions,		//4
		KeySettingOptions,	//5
		Credits,			//6
		Upgrade,			//7
		Gameplay			//8
	};

	public Menutabs menutabs;
	public GameObject[] menuObjects;
	public GameObject[] pageObject;

	private bool inPause = false;
	private bool inUpgrades = false;

	void Start(){
		Time.timeScale = 0;
		SetMenu ((int)Menutabs.StartPage, 1);
	}

	void Update(){
		Pause ();
		UpgradeTab ();
	}

	public void ChangeTab(int id){
		menutabs = (Menutabs)id;
		CheckTab ();
	}

	void CheckTab(){
		switch (menutabs) {
			case Menutabs.StartPage:
			SetMenu ((int)Menutabs.StartPage, 1);
				break;
			case Menutabs.Difficulty:
				SetMenu ((int)Menutabs.Difficulty, 1);
				break;
			case Menutabs.Pause:
				SetMenu ((int)Menutabs.Pause, 2);
				break;
			case Menutabs.SoundOptions:
				SetMenu ((int)Menutabs.SoundOptions, 3);
				break;
			case Menutabs.GraphicOptions:
				SetMenu ((int)Menutabs.GraphicOptions, 3);
				break;
			case Menutabs.KeySettingOptions:
				SetMenu ((int)Menutabs.KeySettingOptions, 3);
				break;
			case Menutabs.Credits:
				SetMenu ((int)Menutabs.Credits, 1);
				break;
			case Menutabs.Upgrade:
				SetMenu ((int)Menutabs.Upgrade, 0);
				break;
			case Menutabs.Gameplay:
				SetMenu ((int)Menutabs.Gameplay, 0);
				Time.timeScale = 1;
				inPause = false;
				break;
		}
	}

	void SetMenu(int num, int showId){
		for (int i = 0; i < menuObjects.Length; i++) {
			menuObjects [i].SetActive (false);
		}

		for (int j = 0; j < pageObject.Length; j++) {
			pageObject [j].SetActive (false);
		} 

		if (showId == 1) {
			pageObject[0].SetActive (true); //startPageObject
		} else if (showId == 2){
			pageObject[1].SetActive (true); //gameMenuObject
		} else if (showId == 3){
			pageObject[1].SetActive (true); //gameMenuObject
			pageObject[2].SetActive (true); //optionsObject
		}

		if (num != (int)Menutabs.Gameplay) {
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

	void UpgradeTab(){
		if (Input.GetButtonDown ("Upgrades")) {
			if (inUpgrades){
				menutabs = Menutabs.Gameplay;
				inUpgrades = false;
				Time.timeScale = 1;
				menuObjects [(int)Menutabs.Upgrade].GetComponent<Upgrade> ().AddPoints ();
			} else {
				menutabs = Menutabs.Upgrade;
				inUpgrades = true;
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
		ChangeTab ((int)Menutabs.Gameplay);
		Time.timeScale = 1;
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
