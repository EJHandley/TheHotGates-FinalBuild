using UnityEngine;
using TMPro;

public class TooltipController : MonoBehaviour
{
    public TurretController turret;

    public TMP_Text costText;
    public TMP_Text damageText;
    public TMP_Text healthText;

    void Update()
    {
        costText.text = ":" + " " + Mathf.Round(turret.stats.purchaseValue).ToString();
        damageText.text = ":" + " " + Mathf.Round(turret.stats.damage).ToString();
        healthText.text = ":" + " " + Mathf.Round(turret.stats.startHealth).ToString();
    }
}
