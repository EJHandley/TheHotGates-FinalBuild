using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public bool isLevel4;

    [Header("Level UI")]
    public GameObject tutorialOverlay;
    public GameObject gameOverUI;
    public GameObject winScreenUI;

    [Header("Level Specific")]
    public string soundtrack;
    public int levelToUnlock;

    void Start()
    {
        GameIsOver = false;

        if(tutorialOverlay != null)
        {
            if (PlayerPrefs.GetInt("levelReached") > 1)
            {
                tutorialOverlay.SetActive(false);
            }
        }

        AudioManager.instance.StopPlaying("MainTheme");
        AudioManager.instance.Play(soundtrack);
        AudioManager.instance.mainThemePlaying = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        PlayerPrefs.SetInt("HighScore", PlayerStats.FinalLevelScore);

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);

        winScreenUI.SetActive(true);
    }
}
