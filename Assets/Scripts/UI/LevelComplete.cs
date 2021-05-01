using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void Continue()
    {
        Debug.Log("WINNER WINNER CHICKEN DINNER");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene("LevelSelect");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
