using UnityEngine;
using System.Collections;

public class WaveSpawning : MonoBehaviour {

	public int waveNumber;
	public int startNumber;
	public int enemyNumber;

	public GameObject enemyPrefab;

	public bool enemysDead;


	void Start () {
	
	}
	
	void Update () {
	
	}

	public int NumberOfEnemeys (){
		

		return enemyNumber;
	}

	public void StartWaveSpawning (){
		enemysDead = true;
		NumberOfEnemeys();
		for(int i = 0; i < enemyNumber; i++){

		}
		
	}

	public void CheckIfWaveDone (){

	}
}
