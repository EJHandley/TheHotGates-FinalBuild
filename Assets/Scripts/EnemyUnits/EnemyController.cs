using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;

    public EnemyStats stats;

    private bool isDead;

    [Header("Unity Parameters")]
    public Image healthBar;

    void Start()
    {
        stats.health = stats.startHealth;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        PlayerStats.SpecialCurrency = PlayerPrefs.GetInt("SpecialCurrency");
    }

    public void GoToObjective()
    {
        Transform target = EnemyObjective.instance.enemyObjective.transform;
        agent.SetDestination(target.position);

        float distanceToObjective = Vector3.Distance(transform.position, target.position);
        if (distanceToObjective <= stats.reachedObjective)
        {
            ObjectiveReached();
        }
    }

    public void ObjectiveReached()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void Attack()
    {

    }

    public void TakeDamage(int amount)
    {
        stats.health -= amount;

        healthBar.fillAmount = stats.health / stats.startHealth;

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);
    }
}
