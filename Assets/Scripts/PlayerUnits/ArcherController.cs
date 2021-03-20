using UnityEngine;

public class ArcherController : MonoBehaviour
{
    private Transform target;
    public TurretStats stats;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    private int skiritaiDamageChange;
    private float skiritaiRangeChange;

    private int peltastDamageChange;
    private float peltastRangeChange;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        skiritaiDamageChange = stats.damage / 20;
        skiritaiRangeChange = stats.attackRange / 20;

        peltastDamageChange = stats.damage / 40;
        peltastRangeChange = stats.attackRange / 10;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= stats.attackRange)
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

        Vector3 dir = (target.position - transform.position);
        Quaternion aimRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(stats.rotationPoint.rotation, aimRotation, Time.deltaTime * stats.turnSpeed).eulerAngles;
        stats.rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (stats.attackReset <= 0f)
        {
            Attack();
            stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;

        if(!UpgradeSystem.SkiritaiIsEnabled && !UpgradeSystem.PeltastIsEnabled)
        {
            return;
        }

        if(UpgradeSystem.SkiritaiIsEnabled)
        {
            SkiritaiUpgradeEnabled();
        }

        if(UpgradeSystem.PeltastIsEnabled)
        {
            PeltastUpgradeEnabled();
        }
    }

    void Attack()
    {
        Damage(target.transform);
    }

    void Damage(Transform enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();

        if (e != null)
        {
            e.TakeDamage(stats.damage);
        }
    }

    void SkiritaiUpgradeEnabled()
    {
        stats.damage += skiritaiDamageChange;
        stats.attackRange += skiritaiRangeChange;
    }

    void PeltastUpgradeEnabled()
    {
        stats.damage += peltastDamageChange;
        stats.attackRange -= peltastRangeChange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
    }
}
