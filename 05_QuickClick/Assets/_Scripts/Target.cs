using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public float minForce = 14.5f;
    public float maxForce = 17;
    public float torqueRange = 10;
    public float positionLimitX = 4;
    public float positionLimitY = -5;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem _ParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-positionLimitX, positionLimitX),positionLimitY);//z=0
    }

    private float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private void OnMouseOver()
    {
        if (gameManager.gameState == GameManager.GameStates.inGame)
        {
            Destroy(gameObject);
            Instantiate(_ParticleSystem, transform.position, _ParticleSystem.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(-pointValue);
            if (gameObject.CompareTag("Good"))
            {
                gameManager.setLives(-1);
            }
        }
    }
}
