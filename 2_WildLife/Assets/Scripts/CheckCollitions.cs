using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollitions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(this.gameObject); //Destruye al animal
            Destroy(other.gameObject); //Destruye lo que toque
        }
    }
}
