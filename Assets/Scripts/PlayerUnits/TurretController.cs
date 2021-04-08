﻿using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    public TurretStats stats;
    public Transform target;

    [Header("Unity Setup Fields")]
    public Image healthBar;
    public string enemyTag = "Enemy";

    private bool isDead;
    public bool isRanged;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        stats.health = stats.startHealth;
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

        if(isRanged)
        {
            LockOnTarget();
        }

        if (stats.attackReset <= 0f)
        {
            if (isRanged)
            {
                Shoot();
            }
            else
            {
                Attack();
            }
            
        stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = (target.position - transform.position);
        Quaternion aimRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(stats.rotationPoint.rotation, aimRotation, Time.deltaTime * stats.turnSpeed).eulerAngles;
        stats.rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(stats.missilePrefab, stats.firePoint.position, stats.firePoint.rotation);
        BoltMissile bolt = projectile.GetComponent<BoltMissile>();
        StoneMissile stone = projectile.GetComponent<StoneMissile>();
        ArrowMissile arrow = projectile.GetComponent<ArrowMissile>();

        if (bolt != null)
        {
            bolt.Seek(target);
        }
        else if (stone != null)
        {
            stone.Seek(target);
        }
        else if (arrow != null)
        {
            arrow.Seek(target);
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

    public void TakeDamage(int amount)
    {
        stats.health -= amount;

        if (stats.health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
