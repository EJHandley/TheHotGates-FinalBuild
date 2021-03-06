using UnityEngine;

public class BallistaController : MonoBehaviour
{
    public TurretStats stats;
  
    public string enemyTag = "Enemy";

    private Transform target;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= stats.attackRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
       
    void Update()
    {
        if(target == null)
        {
            return;
        }

        // Ballista Aiming
        Vector3 dir = (target.position - transform.position);
        Quaternion aimRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(stats.rotationPoint.rotation, aimRotation, Time.deltaTime * stats.turnSpeed).eulerAngles;
        stats.rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        if(stats.attackReset <= 0f)
        {
            Shoot();
            stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject boltFired = Instantiate(stats.missilePrefab, stats.firePoint.position, stats.firePoint.rotation);
        BoltMissile bolt = boltFired.GetComponent<BoltMissile>();

        if(bolt != null)
        {
            bolt.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);    
    }
}
