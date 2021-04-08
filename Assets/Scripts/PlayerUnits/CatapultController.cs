using UnityEngine;

public class CatapultController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    private float greekFireAOEChange;

    private int artilleryDamageChange;
    private float artilleryAOEChange;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        greekFireAOEChange = turret.stats.explosionRadius / 5;

        artilleryDamageChange = turret.stats.damage / 2;
        artilleryAOEChange = turret.stats.explosionRadius / 2;
    }

    void Update()
    {
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
        turret.stats.explosionRadius += greekFireAOEChange;
        //DO SOMETHING
    }

    void ArtilleryUpgradeEnabled()
    {
        turret.stats.damage += artilleryDamageChange;
        turret.stats.explosionRadius -= artilleryAOEChange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
