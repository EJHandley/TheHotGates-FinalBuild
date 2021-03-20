using UnityEngine;
using UnityEngine.UI;

public class StoneWallController : MonoBehaviour
{
    public TurretStats stats;
    private bool isDead;

    [Header("Unity Parameters")]
    public Image healthBar;

    void Start()
    {
       
    }

    void Update()
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
        Destroy(gameObject);
    }
}
