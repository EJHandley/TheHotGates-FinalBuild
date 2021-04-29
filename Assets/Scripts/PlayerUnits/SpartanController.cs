using UnityEngine;

public class SpartanController : MonoBehaviour
{
    public TurretController turret;

    private int isTrue = 1;

    #region Auras
    private int mardoniusSpartanDmgChange;
    private float mardoniusSpartanHthChange;

    private int xerxesSpartanDmgChange;
    private float xerxesSpartanHthChange;

    public bool mardoniusAuraApplied = false;
    public bool xerxesAuraApplied = false;
    #endregion

    private float agogeHealthChange;
    private float agogeSpeedChange;

    private int phalanxDamageChange;
    private float phalanxRangeChange;

    private bool agogeUpgradeApplied = false;
    private bool phalanxUpgradeApplied = false;

    private void Awake()
    {
        AudioManager.instance.Play(turret.stats.buildSound);
    }

    void Start()
    {
        mardoniusSpartanDmgChange = turret.stats.startDamage / 10;
        mardoniusSpartanHthChange = turret.stats.startHealth / 10;

        xerxesSpartanDmgChange = turret.stats.startDamage / 5;
        xerxesSpartanHthChange = turret.stats.startHealth / 5;

        agogeHealthChange = turret.stats.startHealth / 5;
        agogeSpeedChange = turret.stats.attackSpeed;

        phalanxDamageChange = turret.stats.startDamage / 5;
        phalanxRangeChange = turret.stats.startHealth / 4;
    }

    void Update()
    {
        if (agogeUpgradeApplied || phalanxUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("AgogeActivated") == isTrue)
        {
            AgogeUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("ForSpartaActivated") == isTrue)
        {
            PhalanxUpgradeEnabled();
        }
    }

    void AgogeUpgradeEnabled()
    {
        turret.stats.health += agogeHealthChange;
        turret.stats.attackSpeed += agogeSpeedChange;

        agogeUpgradeApplied = true;
    }

    void PhalanxUpgradeEnabled()
    {
        turret.stats.damage += phalanxDamageChange;
        turret.stats.attackRange += phalanxRangeChange;

        phalanxUpgradeApplied = true;
    }

    public void DebuffedByMardonius()
    {
        turret.stats.damage -= mardoniusSpartanDmgChange;
        turret.stats.health -= mardoniusSpartanHthChange;

        mardoniusAuraApplied = true;
    }

    public void DebuffedByXerxes()
    {
        Debug.Log("IVE BEEN DEBUFFED");
        turret.stats.damage -= xerxesSpartanDmgChange;
        turret.stats.health -= xerxesSpartanHthChange;

        xerxesAuraApplied = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turret.stats.attackRange);
    }
}
