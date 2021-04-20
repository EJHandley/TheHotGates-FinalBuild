using UnityEngine;

public class WoodenWallController : MonoBehaviour
{
    public TurretController barricade;

    private int isTrue = 1;

    private int spikesDamageChange;

    private float foloiHealthChange;

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
    }

    void FoloiUpgradeEnabled()
    {
        barricade.stats.startHealth += foloiHealthChange;
    }
}
