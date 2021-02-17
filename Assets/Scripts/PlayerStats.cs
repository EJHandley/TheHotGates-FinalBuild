using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 300;

    public static int Lives;
    public int startLives = 10;

    public TMP_Text currencyCounterText;
    public TMP_Text livesText;

    public void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    public void Update()
    {
        currencyCounterText.text = Mathf.Round(Money) + " Monies";
        livesText.text = Mathf.Round(Lives) + " Lives";
    }

}
