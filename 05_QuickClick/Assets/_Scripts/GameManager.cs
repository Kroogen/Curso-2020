﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targetPrefabs;
    public float spawnRate = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarger());
    }

    IEnumerator SpawnTarger()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

}
