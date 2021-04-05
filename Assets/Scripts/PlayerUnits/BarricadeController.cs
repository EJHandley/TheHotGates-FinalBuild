using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarricadeController : MonoBehaviour
{
    public TurretStats stats;

    [Header("Unity Setup Fields")]
    public Image healthBar;

    private bool isDead;

    private void Start()
    {
        stats.health = stats.startHealth;
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
