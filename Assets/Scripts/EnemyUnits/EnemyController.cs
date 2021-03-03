using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float objectiveRadius = 1f;

    public int value = 10;

    Transform target;
    NavMeshAgent agent;

    [Header("Unity Parameters")]
    public Image healthBar;

    void Start()
    {
        target = EnemyObjective.instance.enemyObjective.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);

        float distanceToObjective = Vector3.Distance(transform.position, target.position);
        if(distanceToObjective <= objectiveRadius)
        {
            ObjectiveReached();
        }
    }

    public void ObjectiveReached()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
