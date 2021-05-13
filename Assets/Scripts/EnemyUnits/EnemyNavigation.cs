using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;
    private EnemyController enemy;
    private Transform target;

    public bool canReachObjective;

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

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(agent.destination, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            canReachObjective = true;
        }
        else if (path.status == NavMeshPathStatus.PathPartial)
        {
            canReachObjective = false;
        }

        float distanceToObjective = Vector3.Distance(transform.position, target.position);
        if(distanceToObjective <= enemy.stats.reachedObjective)
        {
            enemy.ObjectiveReached();
        }
    }
}
