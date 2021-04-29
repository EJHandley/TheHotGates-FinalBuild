using UnityEngine;

public class BallistaController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private float springsRangeUpgrade;
    private float springsSpeedUpgrade;

    private int barbDamageUpgrade;

    private bool springsUpgradeApplied = false;
    private bool barbUpgradeApplied = false;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        springsRangeUpgrade = turret.stats.attackRange / 5;
        springsSpeedUpgrade = turret.stats.attackSpeed / 5;

        barbDamageUpgrade = turret.stats.startDamage / 2;
    }

    void Update()
    {
        if (springsUpgradeApplied || barbUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("SpringsActivated") == isTrue)
        {
            SpringsUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("JointActivated") == isTrue)
        {
            BarbUpgradeEnabled();
        }
    }


    void SpringsUpgradeEnabled()
    {
        turret.stats.attackRange += springsRangeUpgrade;
        turret.stats.attackSpeed += springsSpeedUpgrade;

        springsUpgradeApplied = true;
    }

    void BarbUpgradeEnabled()
    {
        turret.stats.damage += barbDamageUpgrade;

        barbUpgradeApplied = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);    
    }
}
