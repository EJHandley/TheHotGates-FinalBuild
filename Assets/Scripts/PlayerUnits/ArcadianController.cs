using UnityEngine;
using System.Collections.Generic;

public class ArcadianController : MonoBehaviour
{

    private Transform target;
    public TurretStats stats;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    private int arcadianHealthChange;
    private int arcadianValueChange;

    private int wrathDamageChange;
    private float wrathAttackSpeedChange;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        arcadianHealthChange = stats.health / 10;
        arcadianValueChange = stats.value / 50;

        wrathDamageChange = stats.damage / 10;
        wrathAttackSpeedChange = stats.attackSpeed;
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

        if (stats.attackReset <= 0f)
        {
            Attack();
            stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;

        if(!UpgradeSystem.ArcadianIsEnabled && !UpgradeSystem.WrathIsEnabled)
        {
            return;
        }

        if(UpgradeSystem.ArcadianIsEnabled)
        {
            ArcadianUpgradeEnabled();
        }

        if(UpgradeSystem.WrathIsEnabled)
        {
            WrathUpgradeEnabled();
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

    void ArcadianUpgradeEnabled()
    {
        stats.health += arcadianHealthChange;
        stats.value += arcadianValueChange;
    }

    void WrathUpgradeEnabled()
    {
        stats.damage += wrathDamageChange;
        stats.attackSpeed += wrathAttackSpeedChange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
    }
}
