using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private int skiritaiDamageChange;
    private float skiritaiRangeChange;

    private int peltastDamageChange;
    private float peltastRangeChange;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        skiritaiDamageChange = turret.stats.damage / 5;
        skiritaiRangeChange = turret.stats.attackRange / 5;

        peltastDamageChange = turret.stats.damage / 2;
        peltastRangeChange = turret.stats.attackRange / 5;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("SkiritaiActivated") == isTrue)
        {
            SkiritaiUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("PeltastActivated") == isTrue)
        {
            PeltastUpgradeEnabled();
        }
    }

    void ArcherPassive()
    {

    }

    void SkiritaiUpgradeEnabled()
    {
        turret.stats.damage += skiritaiDamageChange;
        turret.stats.attackRange += skiritaiRangeChange;
    }

    void PeltastUpgradeEnabled()
    {
        turret.stats.damage += peltastDamageChange;
        turret.stats.attackRange -= peltastRangeChange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
