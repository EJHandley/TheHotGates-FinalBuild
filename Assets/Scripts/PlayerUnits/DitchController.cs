using UnityEngine;

public class DitchController: MonoBehaviour
{
    public TurretStats stats;
    private Transform target;
    private EnemyController targetEnemy;

    [Header("Ditch Slow Attributes")]
    public float slowStrength = 0.5f;
    public float slowRadius = 1f;

    public float enemyInDitch;
    public float shortestDistance;

    private string enemyTag = "Enemy";

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            enemyInDitch = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyInDitch < slowRadius)
            {
                Debug.Log("AN ENEMY IS IN RANGE");
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyController>();
        }
        else
        {
            target = null;
            Debug.Log("NO ENEMIES");
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Debug.Log("IM GONNA SLOW HIM");
        SlowEnemy();
    }

    void SlowEnemy()
    {
        targetEnemy.Slow(slowStrength);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, slowRadius);
    }
}
