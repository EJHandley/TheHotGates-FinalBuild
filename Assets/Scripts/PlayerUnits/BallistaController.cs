using UnityEngine;

public class BallistaController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private float springsRangeUpgrade;
    private float springsSpeedUpgrade;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        springsRangeUpgrade = turret.stats.attackRange / 5;
        springsSpeedUpgrade = turret.stats.attackSpeed / 5;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("SpringsActivated") == isTrue)
        {
            SpringsUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("JointActivated") == isTrue)
        {
            JointUpgradeEnabled();
        }
    }


    void SpringsUpgradeEnabled()
    {
        turret.stats.attackRange += springsRangeUpgrade;
        turret.stats.attackSpeed += springsSpeedUpgrade;
    }

    void JointUpgradeEnabled()
    {
        //DO SOMETHING
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);    
    }
}
