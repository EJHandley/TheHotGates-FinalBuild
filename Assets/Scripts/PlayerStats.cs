using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public static int NormalCurrency;
    public int startCurrency = 300;

    public static int SpecialCurrency;
    public int startSpecial = 0;

    public static int Lives;
    public int startLives = 10;

    public static int EnemiesKilled;

    public TMP_Text currencyCounterText;
    public TMP_Text livesText;

    public void Start()
    {
        NormalCurrency = startCurrency;
        SpecialCurrency = startSpecial;
        Lives = startLives;
        EnemiesKilled = 0;
    }

    public void Update()
    {
        currencyCounterText.text = Mathf.Round(NormalCurrency) + " Monies";
        livesText.text = Mathf.Round(Lives) + " Lives";
    }

}
