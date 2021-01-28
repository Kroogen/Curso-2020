using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform player;
    private bool isPlayerInRange;
    public GameEnding gameEnding;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        //verifica si hay algo entre gargola y john lemon
        if (isPlayerInRange)
        {
            //se suma vector3.up por que el origen (John Lemon) está en los pies
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position,direction);
            
            //Dibujar un rayo para poder ver elementos invisibles
            Debug.DrawRay(transform.position,direction, Color.magenta, Time.deltaTime, true);
            
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.2f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position,player.position);
    }
}
