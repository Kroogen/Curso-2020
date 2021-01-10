using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public int animalIndex;

    private int spawnRangex = 17;
    private float spawnPositionz;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        spawnPositionz = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangex,spawnRangex), 0, spawnPositionz);
        Instantiate(enemies[animalIndex],
            spawnPos,
            enemies[animalIndex].transform.rotation);
    }
}
