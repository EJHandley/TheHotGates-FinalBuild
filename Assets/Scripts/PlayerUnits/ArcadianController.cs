using UnityEngine;
using UnityEngine.UI;

public class ArcadianController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private int arcadianHealthChange;
    private int arcadianValueChange;

    private int wrathDamageChange;
    private float wrathAttackSpeedChange;

    void Start()
    {
        arcadianHealthChange = turret.stats.health / 10;
        arcadianValueChange = turret.stats.purchaseValue / 50;

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
