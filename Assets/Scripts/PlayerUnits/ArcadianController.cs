using UnityEngine;
using System.Collections.Generic;

public class ArcadianController : MonoBehaviour
{
    private int isTrue = 1;
    private int isFalse = 0;

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
        arcadianValueChange = stats.purchaseValue / 50;

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

        if (PlayerPrefs.GetInt("ArcadianActivated") == isFalse && PlayerPrefs.GetInt("WrathActivated") == isFalse)
        {
            return;
        }

        if (PlayerPrefs.GetInt("ArcadianActivated") == isTrue)
        {
            ArcadianUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("WrathActivated") == isTrue)
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

    void ArcadianPassive()
    {
        
    }

    void ArcadianUpgradeEnabled()
    {
        stats.health += arcadianHealthChange;
        stats.purchaseValue += arcadianValueChange;
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
