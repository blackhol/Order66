using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawning : MonoBehaviour {

	public int waveNumber;
	public int startNumber;
	public int enemyNumber;

	public GameObject enemyPrefab;


	public bool enemysDead;

	public List<GameObject> enemys = new List<GameObject>();

	public float minDifference;
	public float maxDifference;


	void Start () {
		
	
	}
	
	void Update () {

	}
	public Vector3 GenerateSpawnPos (Vector3 source){

		Vector3 _spawnPos;
		_spawnPos = source;
		
		_spawnPos.z = Random.Range(minDifference,maxDifference);
		_spawnPos.x = Random.Range(minDifference,maxDifference);
		print(_spawnPos);


		return _spawnPos;
	}

	public int NumberOfEnemeys (){
		
		enemyNumber = Mathf.RoundToInt(waveNumber * startNumber /1.5f);

		return enemyNumber;
	}

	public void StartWaveSpawning (GameObject spawnFrom){

		
		GameObject tempEnemy;
		NumberOfEnemeys();
		if(enemysDead){
			for(int i = 0; i < enemyNumber; i++){
				tempEnemy = Instantiate(enemyPrefab,GenerateSpawnPos(spawnFrom.transform.position),Quaternion.identity) as GameObject;
				enemys.Add(tempEnemy);
			}
		}
		enemysDead = false;
		
	}

	public void CheckIfWaveDone (){
		for(int i = 0; i <= enemys.Count; i++){
			if(enemys[i] != null){
				enemysDead = false;
				print("Wave not done");

			} else{
				enemysDead = true;
			}
		}

		
	}
}
