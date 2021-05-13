using UnityEngine;

public class ArcadianController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private float highlandHealthChange;
    private int highlandValueChange;

    private int wrathDamageChange;
    private float wrathAttackSpeedChange;

    private bool arcadianUpgradeApplied = false;
    private bool wrathUpgradeApplied = false;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        highlandHealthChange = turret.stats.startHealth / 5;
        highlandValueChange = turret.stats.purchaseValue / 2;

        wrathDamageChange = turret.stats.startDamage / 5;
        wrathAttackSpeedChange = turret.stats.attackSpeed;
    }

    void Update()
    {
        if (arcadianUpgradeApplied || wrathUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("ArcadianActivated") == isTrue)
        {
            ArcadianUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("WrathActivated") == isTrue)
        {
            WrathUpgradeEnabled();
        }
    }

    void ArcadianUpgradeEnabled()
    {
        turret.stats.health += highlandHealthChange;
        turret.stats.purchaseValue -= highlandValueChange;

        arcadianUpgradeApplied = true;
    }

    void WrathUpgradeEnabled()
    {
        turret.stats.damage += wrathDamageChange;
        turret.stats.attackSpeed += wrathAttackSpeedChange;

        wrathUpgradeApplied = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
