using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameManager gameManager;

    public void Continue()
    {
        AudioManager.instance.StopPlaying(gameManager.soundtrack);
        SceneManager.LoadScene("LevelSelect");
    }

    public void Menu()
    {
        AudioManager.instance.StopPlaying(gameManager.soundtrack);
        SceneManager.LoadScene("MainMenu");
    }

}
