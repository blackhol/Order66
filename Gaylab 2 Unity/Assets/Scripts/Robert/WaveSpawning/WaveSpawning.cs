using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawning : MonoBehaviour {

	public int waveNumber;
	public int startNumber;
	public int enemyNumber;

	public GameObject enemyPrefab;

	public Transform[] spawnPos;

	public bool enemysDead;

	public List<GameObject> enemys = new List<GameObject>();


	void Start () {
	
	}
	
	void Update () {
	
	}

	public int NumberOfEnemeys (){
		
		enemyNumber = (waveNumber * startNumber /2);

		return enemyNumber;
	}

	public void StartWaveSpawning (){
		enemysDead = true;
		GameObject tempEnemy;
		NumberOfEnemeys();
		for(int i = 0; i < enemyNumber; i++){
			tempEnemy = enemyPrefab;
			enemys.Add(tempEnemy);
			Instantiate(tempEnemy,spawnPos[1].position,Quaternion.identity);
		}
		
	}

	public void CheckIfWaveDone (){

	}
}
