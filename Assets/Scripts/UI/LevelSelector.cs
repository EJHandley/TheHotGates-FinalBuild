using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public AudioManager audioManager;
    public Button[] levelButtons;

    private int levelReached;

    public GameObject highScore;
    public TMP_Text counterText;

    void Start()
    {
        levelReached = PlayerPrefs.GetInt("levelReached");
        Debug.Log(levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }

        if (AudioManager.instance.mainThemePlaying == false)
        {
            AudioManager.instance.Play("MainTheme");
            AudioManager.instance.mainThemePlaying = true;
        }

        if (PlayerPrefs.GetInt("HighScore") > 0)
        {
            highScore.SetActive(true);
            counterText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void Update()
    {
        levelReached = PlayerPrefs.GetInt("levelReached");
        Debug.Log(levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerPrefs.SetInt("levelReached", 4);
        }
    }

    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ResetLevelSelect()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
