using UnityEngine;
using TMPro;

public class ArcadianController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private float arcadianHealthChange;
    private int arcadianValueChange;

    private int wrathDamageChange;
    private float wrathAttackSpeedChange;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        arcadianHealthChange = turret.stats.health / 10;
        arcadianValueChange = turret.stats.purchaseValue / 2;

        wrathDamageChange = turret.stats.damage / 10;
        wrathAttackSpeedChange = turret.stats.attackSpeed;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("ArcadianActivated") == isTrue)
        {
            ArcadianUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("WrathActivated") == isTrue)
        {
            WrathUpgradeEnabled();
        }
    }

    void ArcadianPassive()
    {
        
    }

    void ArcadianUpgradeEnabled()
    {
        turret.stats.health += arcadianHealthChange;
        turret.stats.purchaseValue += arcadianValueChange;
    }

    void WrathUpgradeEnabled()
    {
        turret.stats.damage += wrathDamageChange;
        turret.stats.attackSpeed += wrathAttackSpeedChange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
