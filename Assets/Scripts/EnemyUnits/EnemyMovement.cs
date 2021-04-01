using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovement : MonoBehaviour
{
    public GameObject waypointObject;
    private EnemyController enemy;
    private NavMeshAgent agent;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        enemy = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
        
        target = Waypoints.points[0];
    }

    void Update()
    {
        if (!waypointObject.activeInHierarchy)
            return;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.stats.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length -1)
        {
            ObjectiveReached();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void ObjectiveReached()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
