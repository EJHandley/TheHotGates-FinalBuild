﻿using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour
{
    private EnemyController enemy;
    private NavMeshAgent agent;

    void Awake()
    {
        enemy = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.speed = enemy.stats.speed;

        if (enemy.target != null)
        {
            agent.SetDestination(enemy.target.GetChild(0).position);
        }

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(agent.destination, path);

        if(path.status == NavMeshPathStatus.PathPartial)
        {
            enemy.target.tag = "Unreachable";
        }

        Debug.Log(agent.pathStatus);
    }
}
