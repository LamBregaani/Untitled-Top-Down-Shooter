using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectMoveToPlayer : MonoBehaviour
{
    [SerializeField] private float range;

    [SerializeField] private float maxSpeed;

    private NavMeshAgent agent;

    private PlayerHealth player;

    private float distance;

    private bool nearPlayer;



    private void Awake()
    {
        if(maxSpeed == 0)
        {
            maxSpeed = 3.5f;
        }

        agent = GetComponent<NavMeshAgent>();

        
    }

    private void Update()
    {
        
        if(nearPlayer)
        {
            MoveToPlayer();
        }
        else
        {
            Stopped();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        player = other.GetComponentInParent<PlayerHealth>();
        if(player != null)
        {
            nearPlayer = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponentInParent<PlayerHealth>() == player)
        {
            nearPlayer = false;
        }
    }


    private void MoveToPlayer()
    {
        agent.isStopped = false;
        if(player)
        agent.destination = player.transform.position;
        SpeedRampUp();
    }

    private void SpeedRampUp()
    {
        
        for (float i = 0; i < maxSpeed; i += 0.5f * Time.deltaTime)
        {
            agent.speed = i;
        }
    }

    private void Stopped()
    {
        agent.isStopped = true;
    }

}
