using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    public TurretStats stats;
    public Transform target;

    [Header("Unity Setup Fields")]
    public Image healthBar;
    public GameObject healthBarUI;
    public string enemyTag = "Enemy";

    [HideInInspector]
    public bool isDead;

    public bool isRanged;
    public bool isBarricade;

    [Header("Other")]
    public GameObject rangeIndicator;
    public GameObject attackPoint;

    private bool turretSelected;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        stats.health = stats.startHealth;
        stats.damage = stats.startDamage;
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
        if(!isBarricade)
        {
            if(turretSelected == true)
            {
                rangeIndicator.SetActive(true);
            }
            else
            {
                rangeIndicator.SetActive(false);
            }
        }

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
            else if (!isBarricade)
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

    public void Damage(Transform enemy)
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

        if(stats.health < stats.startHealth)
        {
            healthBarUI.SetActive(true);
        }

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

        if (!isBarricade)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (turretSelected == true)
        {
            turretSelected = false;
        }
        else
        {
            turretSelected = true;
        }
    }
}
