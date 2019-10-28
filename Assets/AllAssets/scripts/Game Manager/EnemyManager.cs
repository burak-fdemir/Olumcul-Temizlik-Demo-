using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private GameObject boarPrefab, cannibalPrefab;

    public Transform[] cannibalSpawnPoints, boarSpawnPoints;

    [SerializeField]
    private int canibalEnemyCount, boarEnemyCount;

    private int initialCanibalCount, initialBoarCount;

    public float waitBeforeSpawnEnemiesTime = 10f;

	void Awake () {
        MakeInstance();
	}

    void Start() {
        initialCanibalCount = canibalEnemyCount;
        initialBoarCount = boarEnemyCount;

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }
	
	void MakeInstance() { 
        if(instance == null) {
            instance = this;
        
        }
    
    }

    private void SpawnEnemies() {
        SpawnCannibals();
        SpawnBoars();
    }

    private void SpawnCannibals() {

        //for(int i = 0; i <= cannibalSpawnPoints.Length - 1; i++) {

        //    Instantiate(cannibalPrefab,cannibalSpawnPoints[i].position,Quaternion.identity);
        //}

        int index = 0;

        for(int i =0; i< canibalEnemyCount; i++) { 
        
            if(index >= cannibalSpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(cannibalPrefab, cannibalSpawnPoints[i].position, Quaternion.identity);
            index++;
        }
        canibalEnemyCount = 0;
    
    
    }

    private void SpawnBoars() {
        int index = 0;

        for (int i = 0; i < boarEnemyCount; i++)
        {

            if (index >= boarSpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(boarPrefab, boarSpawnPoints[i].position, Quaternion.identity);
            index++;
        }
        boarEnemyCount = 0;


    }

    IEnumerator CheckToSpawnEnemies() {

        yield return new WaitForSeconds(waitBeforeSpawnEnemiesTime);

        SpawnCannibals();
        SpawnBoars();

        StartCoroutine("CheckToSpawnEnemies");


    }

    public void EnemyDied(bool cannibal) {
        if (cannibal) {
            canibalEnemyCount++;

            if(canibalEnemyCount > initialCanibalCount) {
                canibalEnemyCount = initialCanibalCount;
            }
        
        }
        else {

            boarEnemyCount++;

            if (boarEnemyCount > initialBoarCount)
            {
                boarEnemyCount = initialBoarCount;
            }

        }
    
    }

    public void StopSpawning() {

        StartCoroutine("CheckToSpawnEnemies");

    }
}
