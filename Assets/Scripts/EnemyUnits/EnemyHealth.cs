using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public EnemyStats stats;
    public Image healthBar;

    private void Start()
    {
        stats.health = stats.startHealth;
    }

    public void TakeDamage(int amount)
    {
        stats.health -= amount;

        healthBar.fillAmount = stats.health / stats.startHealth;

        if (stats.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerStats.NormalCurrency += stats.normalValue;
        PlayerStats.SpecialCurrency += stats.specialValue;
        PlayerStats.EnemiesKilled ++;
    }

}
