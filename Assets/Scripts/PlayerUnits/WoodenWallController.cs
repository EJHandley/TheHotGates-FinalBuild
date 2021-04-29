using UnityEngine;

public class WoodenWallController : MonoBehaviour
{
    public TurretController barricade;

    private int isTrue = 1;

    private int spikesDamageChange;

    private float foloiHealthChange;

    private bool spikesUpgradeApplied = false;
    private bool foloiUpgradeApplied = false;

    private void Awake()
    {
        AudioManager.instance.Play(barricade.stats.buildSound);
    }

    void Start()
    {
        spikesDamageChange = 5;
        foloiHealthChange = barricade.stats.startHealth;
    }

    void Update()
    {
        if (spikesUpgradeApplied || foloiUpgradeApplied)
            return;

        if (PlayerPrefs.GetInt("SpikesActivated") == isTrue)
        {
            SpikesUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("FoloiActivated") == isTrue)
        {
            FoloiUpgradeEnabled();
        }
    }

    void SpikesUpgradeEnabled()
    {
        barricade.stats.damage += spikesDamageChange;

        spikesUpgradeApplied = true;
    }

    void FoloiUpgradeEnabled()
    {
        barricade.stats.startHealth += foloiHealthChange;

        foloiUpgradeApplied = true;
    }
}
