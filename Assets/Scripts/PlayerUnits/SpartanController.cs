using UnityEngine;

public class SpartanController : MonoBehaviour
{
    private Transform target;
    public TurretStats stats;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    private int agogeDamageChange;
    private int agogeHealthChange;

    private int forSpartaPassiveChange;

    private void Awake()
    {
        AudioManager.instance.Play("SpartanSpawn");
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        agogeDamageChange = stats.damage / 20;
        agogeHealthChange = stats.health / 20;

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

        if(!UpgradeSystem.AgogeIsEnabled && !UpgradeSystem.SpartaIsEnabled)
        {
            return;
        }

        if(UpgradeSystem.AgogeIsEnabled)
        {
            AgogeUpgradeEnabled();
        }

        if(UpgradeSystem.SpartaIsEnabled)
        {
            ForSpartaUpgradeEnabled();
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

    void AgogeUpgradeEnabled()
    {
        stats.damage += agogeDamageChange;
        stats.health += agogeHealthChange;
    }

    void ForSpartaUpgradeEnabled()
    {
        //DO SOMETHING
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
    }
}
