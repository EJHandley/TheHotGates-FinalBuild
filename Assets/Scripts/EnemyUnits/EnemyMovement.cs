using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour
{
    private EnemyController enemy;
    private NavMeshAgent agent;
    private EnemyNavigation nav;

    void Awake()
    {
        enemy = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
        nav = GetComponent<EnemyNavigation>();
    }

    private void Update()
    {
        agent.speed = enemy.stats.speed;

        if (enemy.target != null && nav.canReachObjective == false)
        {
            agent.SetDestination(enemy.target.GetChild(0).position);
        }
    }
}
