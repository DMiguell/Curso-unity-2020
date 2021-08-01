﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    private bool isPlayerInRange;

    public GameEnding gameEnding;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            isPlayerInRange = true;
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform== player)
        {
            isPlayerInRange = false;
        }
    }
    private void Update()
    {
        if(isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position+ Vector3.up;
            Ray ray = new Ray(transform.position,direction);
            RaycastHit raycastHit;

            Debug.DrawRay(transform.position,direction,Color.green,Time.deltaTime,true);
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform== player)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        // solo existe a produccion en unity en el juego compilado no
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position,player.position+Vector3.up);


    }
}
