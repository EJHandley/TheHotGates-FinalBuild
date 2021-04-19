using UnityEngine;
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
        if(enemy.target != null)
        {
            agent.SetDestination(enemy.target.position);
        }

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(agent.destination, path);

        if(path.status == NavMeshPathStatus.PathPartial)
        {
            enemy.target.tag = "Unreachable";
        }

        Debug.Log(agent.pathStatus);

        agent.speed = enemy.stats.speed;
    }
}
