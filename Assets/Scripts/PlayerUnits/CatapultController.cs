using UnityEngine;

public class CatapultController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private int greekFireDamageChange;
    private float greekFireAOEChange;

    private int artilleryDamageChange;
    private float artilleryAOEChange;

    private bool greekFireUpgradeApplied;
    private bool artilleryUpgradeApplied;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        greekFireDamageChange = turret.stats.startDamage / 10;
        greekFireAOEChange = turret.stats.explosionRadius / 5;

        artilleryDamageChange = turret.stats.startDamage / 2;
        artilleryAOEChange = turret.stats.explosionRadius / 2;
    }

    void Update()
    {
        if (greekFireUpgradeApplied || artilleryUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("GreekFireActivated") == isTrue)
        {
            GreekFireUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("AtilleryActivated") == isTrue)
        {
            ArtilleryUpgradeEnabled();
        }
    }

    void GreekFireUpgradeEnabled()
    {
        turret.stats.damage += greekFireDamageChange;
        turret.stats.explosionRadius += greekFireAOEChange;

        greekFireUpgradeApplied = true;
    }

    void ArtilleryUpgradeEnabled()
    {
        turret.stats.damage += artilleryDamageChange;
        turret.stats.explosionRadius -= artilleryAOEChange;

        artilleryUpgradeApplied = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
