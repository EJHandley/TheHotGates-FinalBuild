using UnityEngine;

public class SpartanController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private int agogeDamageChange;
    private int agogeHealthChange;

    private int forSpartaPassiveChange;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        agogeDamageChange = turret.stats.damage / 5;
        agogeHealthChange = turret.stats.health / 5;

    }

    void Update()
    {
        if (PlayerPrefs.GetInt("AgogeActivated") == isTrue)
        {
            AgogeUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("ForSpartaActivated") == isTrue)
        {
            ForSpartaUpgradeEnabled();
        }
    }

    void SpartanPassive()
    {

    }

    void AgogeUpgradeEnabled()
    {
        turret.stats.damage += agogeDamageChange;
        turret.stats.health += agogeHealthChange;
    }

    void ForSpartaUpgradeEnabled()
    {
        //DO SOMETHING
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
