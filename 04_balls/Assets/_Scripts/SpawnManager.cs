using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int spawnRange = 9;
    public int enemyCount;
    private int enemyTotal;
    public GameObject powerUpPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyTotal = 1;
        spawnEnemyWaves(enemyTotal++);
    }

    private void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            spawnEnemyWaves(enemyTotal++);

            int numberofPowerUps = Random.Range(0, 3);
            for (int i = 0; i < numberofPowerUps; i++)
            {
                Instantiate(powerUpPrefab, GenerateSpawnPositions(), powerUpPrefab.transform.rotation);
            }
        }
    }

    private Vector3 GenerateSpawnPositions()
    {
        float positionx = Random.Range(-spawnRange,spawnRange);
        float positionz = Random.Range(-spawnRange,spawnRange);
        return new Vector3(positionx, 0, positionz);
    }

    private void spawnEnemyWaves(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPositions(), enemyPrefab.transform.rotation);
        }
    }

}
