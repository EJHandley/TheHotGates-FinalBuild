﻿using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;

    public Transform target;

    private bool isDead;

    private EnemyNavigation goToObjective;
    private EnemyMovement attackEnemies;

    [Header("Unity Parameters")]
    public Image healthBar;
    private string turretTag = "Turret";
  
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        goToObjective = GetComponent<EnemyNavigation>();
        attackEnemies = GetComponent<EnemyMovement>();

        stats.health = stats.startHealth;
        stats.speed = stats.startSpeed;
    }

    void UpdateTarget()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag(turretTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject turret in turrets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, turret.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = turret;
            }
        }

        if (nearestEnemy != null && !goToObjective.canReachObjective)
        {
            target = nearestEnemy.transform;
            goToObjective.enabled = false;
            attackEnemies.enabled = true;
            return;
        }
        else
        {
            target = null;
            attackEnemies.enabled = false;
            goToObjective.enabled = true;
        }
    }

    void Update()
    {
        PlayerStats.SpecialCurrency = PlayerPrefs.GetInt("SpecialCurrency");

        if (target == null)
        {
            return;
        }

        float distanceToEnemy = Vector3.Distance(transform.position, target.transform.GetChild(0).position);
        if (stats.attackReset <= 0f && distanceToEnemy <= stats.attackRange)
        {
            Attack();
            stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;
    }

    void Attack()
    {
        Damage(target.transform);
    }

    void Damage(Transform turret)
    {
        TurretController t = turret.GetComponent<TurretController>();

        if (t != null)
        {
            t.TakeDamage(stats.damage);
        }
    }

    public void TakeDamage(int amount)
    {
        stats.health -= amount;

        float healthLeft = stats.health / stats.startHealth;
        healthBar.fillAmount = healthLeft;

        if (stats.health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        PlayerStats.NormalCurrency += stats.normalValue;
        PlayerStats.SpecialCurrency += stats.specialValue;
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + stats.specialValue);
        PlayerStats.EnemiesKilled++;

        Destroy(gameObject);
    }

    public void ObjectiveReached()
    {
        if(!GameManager.GameIsOver)
        {
            PlayerStats.Lives--;
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
    }
}
