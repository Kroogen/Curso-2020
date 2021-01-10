using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [Tooltip("Objetos que aparecerán")]
    public GameObject[] enemies;

    public int retardoInicio = 0;
    public float intervalo = 4;
    private PlayerController _playerController;
    
    private void Start()
    {
        InvokeRepeating("SpawnObstacle",retardoInicio,
            Random.Range(2,intervalo));
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if (!_playerController.gameOver)
        {
            int pos = Random.Range(0, enemies.Length);
            Instantiate(enemies[pos],
                this.transform.position,
                enemies[pos].transform.rotation);
        }
    }
}
