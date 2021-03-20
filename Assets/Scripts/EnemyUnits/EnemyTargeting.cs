using UnityEngine;
using UnityEngine.AI;

public class EnemyTargeting : MonoBehaviour
{
    public EnemyController enemyController;

    private Transform target;

    private string turretTag = "Turret";

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag(turretTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTurret = null;

        foreach (GameObject turret in turrets)
        {
            float distanceToTurret = Vector3.Distance(transform.position, turret.transform.position);
            if (distanceToTurret < shortestDistance)
            {
                shortestDistance = distanceToTurret;
                nearestTurret = turret;
            }
        }

        if (nearestTurret != null && shortestDistance <= enemyController.stats.attackRange)
        {
            target = nearestTurret.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            enemyController.agent.enabled = true;
            enemyController.GoToObjective();
            Debug.Log("THERES NO ENEMIES");
            return;
        }

        if (enemyController.stats.attackReset <= 0f)
        {
            enemyController.Attack();
            enemyController.stats.attackReset = 1f / enemyController.stats.attackSpeed;
        }
    }
}
