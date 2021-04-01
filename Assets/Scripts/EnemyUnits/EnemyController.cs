using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;

    private bool isDead;

    [Header("Unity Parameters")]
    public Image healthBar;

    void Start()
    {
        stats.health = stats.startHealth;
        stats.speed = stats.startSpeed;
    }

    void Update()
    {
        PlayerStats.SpecialCurrency = PlayerPrefs.GetInt("SpecialCurrency");
    }

    public void Attack()
    {

    }

    public void Slow(float pct)
    {
        stats.speed = stats.startSpeed * (1f - pct);
        Debug.Log("IVE BEEN SLOWED");
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
