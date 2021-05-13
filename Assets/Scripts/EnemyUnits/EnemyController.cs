using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameManager gameManager;

    public EnemyStats stats;
    public EnemyAura auras;

    public Transform target;

    private bool isDead;

    #region Auras
    [Header("Aura Bools")]
    public bool isGeneral;
    public bool Artapanus;
    public bool Hydarnes;
    public bool Mardonius;
    public bool Xerxes;

    [Header("Aura Changes")]
    private int artapanusAuraChange;
    private float hydarnesAuraChange;
    private int xerxesAuraDmgChange;
    private float xerxesAuraHthChange;

    [HideInInspector]
    public bool artapanusAuraApplied = false;
    [HideInInspector]
    public bool hydarnesAuraApplied = false;
    [HideInInspector]
    public bool xerxesAuraApplied = false;
    #endregion

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

        artapanusAuraChange = stats.startDamage / 10;
        hydarnesAuraChange = stats.startHealth / 10;

        xerxesAuraDmgChange = stats.startDamage / 5;
        xerxesAuraHthChange = stats.startHealth / 5;

        stats.damage = stats.startDamage;
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
            return;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        PlayerStats.SpecialCurrency = PlayerPrefs.GetInt("SpecialCurrency");

        if (isGeneral)
        {
            Aura();
        }

        if (target == null)
        {
            return;
        }

        float distanceToEnemy = Vector3.Distance(transform.position, target.transform.GetChild(0).position);
        if (stats.attackReset <= 0f && distanceToEnemy <= stats.attackRange)
        {
            LockOnTarget();
            Attack();
            stats.attackReset = 1f / stats.attackSpeed;
        }

        stats.attackReset -= Time.deltaTime;
    }

    void Aura()
    {
        if(Artapanus)
        {
            auras.ArtapanusAura();
        }

        if(Hydarnes)
        {
            auras.HydarnesAura();
        }

        if(Mardonius)
        {
            auras.MardoniusAura();
        }

        if(Xerxes)
        {
            auras.XerxesAura();
        }
    }

    public void BuffedByArtapanus()
    {
        stats.damage += artapanusAuraChange;
        artapanusAuraApplied = true;
    }   
    
    public void BuffedByHydarnes()
    {
        stats.health += hydarnesAuraChange;
        hydarnesAuraApplied = true;
    }

    public void BuffedByXerxes()
    {
        stats.damage += xerxesAuraDmgChange;
        stats.health += xerxesAuraHthChange;
        xerxesAuraApplied = true;
    }

    void LockOnTarget()
    {
        Vector3 dir = (target.position - transform.position);
        Quaternion aimRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(stats.rotationPoint.rotation, aimRotation, Time.deltaTime * stats.turnSpeed).eulerAngles;
        stats.rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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

    public void TakeDamage(float amount)
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

        if (gameManager.isLevel4)
        {
            PlayerStats.FinalLevelScore++;
        }

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
