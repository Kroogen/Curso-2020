using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;
    private float forwardInput;
    private GameObject focalPoint;
    public float powerUpForce;
    private bool hasPowerUp;
    public int waitTime;
    public GameObject[] powerUpIndicators;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        moveForce = 3;
        powerUpForce = 20;
        waitTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput);

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }

        if (transform.position.y < -3)
        {
            SceneManager.LoadScene("Prototype 4");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator powerUpCountdown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            indicator.gameObject.SetActive(false);
        }
        hasPowerUp = false;
    }

}
