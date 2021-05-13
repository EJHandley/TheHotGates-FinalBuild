using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private int skiritaiDamageChange;
    private float skiritaiRangeChange;

    private int peltastDamageChange;
    private float peltastRangeChange;

    private bool skiritaiUpgradeApplied = false;
    private bool peltastUpgradeApplied = false;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        skiritaiDamageChange = turret.stats.startDamage / 5;
        skiritaiRangeChange = turret.stats.attackRange / 5;

        peltastDamageChange = turret.stats.startDamage / 2;
        peltastRangeChange = turret.stats.attackRange / 5;
    }

    void Update()
    {
        if (skiritaiUpgradeApplied || peltastUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("SkiritaiActivated") == isTrue)
        {
            SkiritaiUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("PeltastActivated") == isTrue)
        {
            PeltastUpgradeEnabled();
        }
    }

    void SkiritaiUpgradeEnabled()
    {
        turret.stats.damage += skiritaiDamageChange;
        turret.stats.attackRange += skiritaiRangeChange;

        skiritaiUpgradeApplied = true;
    }

    void PeltastUpgradeEnabled()
    {
        turret.stats.damage += peltastDamageChange;
        turret.stats.attackRange -= peltastRangeChange;

        peltastUpgradeApplied = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
