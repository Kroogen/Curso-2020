using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField,Tooltip("Personaje a seguir")]
    private GameObject player;

    [SerializeField, Tooltip("Distancia de la cam")]
    private Vector3 offset = new Vector3(0,5,-6);
    
    private void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}
