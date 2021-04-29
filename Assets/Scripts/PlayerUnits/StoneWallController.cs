using UnityEngine;

public class StoneWallController : MonoBehaviour
{
    public TurretController barricade;

    private int isTrue = 1;

    private float pozzolanicHealthChange;
    private bool pozzolanicUpgradeApplied = false;

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
        if (PlayerPrefs.GetInt("PozzolanicActivated") == isTrue && !pozzolanicUpgradeApplied)
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

        pozzolanicUpgradeApplied = true;
    }

    void SappedUpgradeEnabled()
    {
        if(barricade.isDead == true)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, barricade.stats.explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                barricade.Damage(collider.transform);
            }
        }
    }
}
