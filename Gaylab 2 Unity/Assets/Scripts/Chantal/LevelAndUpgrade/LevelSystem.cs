/* 7S_LVLS_001 
 * Made by: Chantal
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	public int maxLevel = 10;
	public float expToLevelOne = 100;
	public Text expTxt;
	public Text lvlTxt;
	public Image expBar;
	public Upgrade upgrade;

	private int level = 1;
	private float curExp = 0;
	private float expToNextLvl;

	void Start(){
		ExpBar ();
		expTxt.text =  "0% EXP";
	}

	public void GainExp(float exp){
		float neededExp = ExpToNextLevel()-curExp;
		if (level < maxLevel) {
			if (exp < neededExp) {
				curExp += exp;
			} else if (exp == neededExp) {
				level++;
				upgrade.AddPoints ();
				curExp = 0;
			} else {
				float leftOverExp = 0;
				leftOverExp = exp - neededExp;
				level++;
				upgrade.AddPoints ();
				if (level < maxLevel) {
					curExp = leftOverExp;
				}
			}
			ExpBar ();
		}
	}

	void ExpBar(){
		lvlTxt.text = "" +level;

		float curExpPrecent = curExp / ExpToNextLevel ();
		expTxt.text =  (curExpPrecent * 100) + "% EXP";
		expBar.fillAmount = curExpPrecent;
	}
		
	float ExpToNextLevel (){
		expToNextLvl = level * expToLevelOne;
		return expToNextLvl;
	}
}
