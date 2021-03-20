using UnityEngine;

public class CatapultController : MonoBehaviour
{
    public TurretStats stats;

    public string enemyTag = "Enemy";

    private Transform target;

    private float greekFireAOEChange;

    private int artilleryDamageChange;
    private float artilleryAOEChange;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        greekFireAOEChange = stats.explosionRadius / 20;

        artilleryDamageChange = stats.damage / 50;
        artilleryAOEChange = stats.explosionRadius / 50;
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
        if (target == null)
        {
            return;
        }

        // Catapult Aiming
        Vector3 dir = (target.position - transform.position);
        Quaternion aimRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(stats.rotationPoint.rotation, aimRotation, Time.deltaTime * stats.turnSpeed).eulerAngles;
        stats.rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (stats.attackReset <= 0f)
        {
            Shoot();
            stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;

        if(!UpgradeSystem.GreekFireIsEnabled && !UpgradeSystem.ArtilleryIsEnabled)
        {
            return;
        }

        if(UpgradeSystem.GreekFireIsEnabled)
        {
            GreekFireUpgradeEnabled();
        }

        if(UpgradeSystem.ArtilleryIsEnabled)
        {
            ArtilleryUpgradeEnabled();
        }
    }

    void Shoot()
    {
        GameObject stoneFired = Instantiate(stats.missilePrefab, stats.firePoint.position, stats.firePoint.rotation);
        StoneMissile projectile = stoneFired.GetComponent<StoneMissile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }

    void GreekFireUpgradeEnabled()
    {
        stats.explosionRadius += greekFireAOEChange;
        //DO SOMETHING
    }

    void ArtilleryUpgradeEnabled()
    {
        stats.damage += artilleryDamageChange;
        stats.explosionRadius -= artilleryAOEChange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
    }
}
