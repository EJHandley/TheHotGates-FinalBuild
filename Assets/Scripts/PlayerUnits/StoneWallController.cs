using UnityEngine;

public class StoneWallController : MonoBehaviour
{
    public TurretController barricade;

    private int isTrue = 1;

    private float pozzolanicHealthChange;

    private void Awake()
    {
        AudioManager.instance.Play(barricade.stats.buildSound);
    }

    void Start()
    {
        pozzolanicHealthChange = barricade.stats.startHealth / 2;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("PozzolanicActivated") == isTrue)
        {
            PozzolanicUpgradeEnabled();
        }

        if (PlayerPrefs.GetInt("SappedActivated") == isTrue)
        {
            SappedUpgradeEnabled();
        }
    }

    void PozzolanicUpgradeEnabled()
    {
        barricade.stats.startHealth += pozzolanicHealthChange;
    }

    void SappedUpgradeEnabled()
    {

    }
}
