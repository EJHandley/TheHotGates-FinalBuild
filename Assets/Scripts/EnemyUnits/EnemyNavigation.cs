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
        GoToObjective();
        agent.speed = enemy.stats.speed;
    }

    void GoToObjective()
    {
        agent.SetDestination(target.position);

        float distanceToObjective = Vector3.Distance(transform.position, target.position);
        if(distanceToObjective <= enemy.stats.reachedObjective)
        {
            enemy.ObjectiveReached();
        }
    }
}
