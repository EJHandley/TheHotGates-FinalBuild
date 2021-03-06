using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public static int NormalCurrency;
    public int startCurrency = 300;

    public static int Lives;
    public int startLives = 10;

    public static int EnemiesKilled;

    public static int SpecialCurrency;

    public TMP_Text currencyCounterText;
    public TMP_Text specialCurrencyCounterText;
    public TMP_Text livesText;

    public void Start()
    {
        NormalCurrency = startCurrency;
        Lives = startLives;
        EnemiesKilled = 0;

        int specialCurrency = PlayerPrefs.GetInt("SpecialCurrency", 0);
        SpecialCurrency = specialCurrency;
    }

    public void Update()
    {
        currencyCounterText.text = Mathf.Round(NormalCurrency) + "";
        specialCurrencyCounterText.text = Mathf.Round(SpecialCurrency) + "";
        livesText.text = Mathf.Round(Lives) + "";
    }

}
