using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundScore : MonoBehaviour
{

    public TMP_Text enemiesKilledText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        enemiesKilledText.text = "0";
        int enemiesKilled = 0;

        yield return new WaitForSeconds(.7f);

        while (enemiesKilled < PlayerStats.EnemiesKilled)
        {
            enemiesKilled++;
            enemiesKilledText.text = enemiesKilled.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }

}
