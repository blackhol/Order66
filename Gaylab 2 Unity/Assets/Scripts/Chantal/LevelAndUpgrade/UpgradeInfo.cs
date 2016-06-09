using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeInfo : MonoBehaviour {

	public Text infoTextField;

	void Start (){
		StandardInfo ();
	}

	public void GunInfo(){
		infoTextField.text = "\t\t\t\t<b>Gun upgrade</b> " +
			"\n~~~~~~~~~~~~~~~~~~~~~~~~"+
			"\nLevel 1: cooldown reduce." +
			"\n\nLevel 2: strength increase, max ammo increase and the ammo stack reset to max." +
			"\n\nLevel 3: cooldown remove,  max ammo increase and the ammo stack reset to max.";
	}

	public void RocketInfo(){
		infoTextField.text = "\t\t\t<b>Rocket upgrade</b> " +
			"\n~~~~~~~~~~~~~~~~~~~~~~~~"+
			"\nLevel 1: strength increase." + 
			"\n\nLevel 2: cooldown reduce,  max ammo increase and the ammo stack reset to max." +
			"\n\nLevel 3: strength increase, max ammo increase and the ammo stack reset to max.";
	}

	public void SwordInfo(){
		infoTextField.text = "\t\t\t<b>Sword upgrade</b> " +
			"\n~~~~~~~~~~~~~~~~~~~~~~~~"+
			"\nLevel 1: cooldown remove." + 
			"\n\nLevel 2: strength increase." +
			"\n\nLevel 3: strength increase, range increase.";
	}

	public void MobilityInfo(){
		infoTextField.text = "\t\t\t<b>Mobility upgrade</b> " +
			"\n~~~~~~~~~~~~~~~~~~~~~~~~"+
			"\nLevel 1: enable jump ability." + 
			"\n\nLevel 2: walk and dash speed increase." +
			"\n\nLevel 3: dash may give damage to enemies.";
	}

	public void StandardInfo(){
		infoTextField.text = "If you have upgrade points you can upgrade your weapons or mobility." + 
			"\n\nHold your mouse on the upgrade buttons to get more info on the upgrade.";
	}


}
