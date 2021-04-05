using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
public class EnemyNavigation : MonoBehaviour
{
    private EnemyController enemy;
    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        enemy = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();

        target = EnemyObjective.instance.enemyObjective.transform;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        agent.speed = enemy.stats.speed;
    }
}
