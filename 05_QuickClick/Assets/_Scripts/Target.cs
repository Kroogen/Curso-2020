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

    // Start is called before the first frame update
    void Start()
    {
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
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
