using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string levelToLoad = "LevelSelect";

    private void Start()
    {
        if (AudioManager.instance.mainThemePlaying == false)
        {
            AudioManager.instance.Play("MainTheme");
            AudioManager.instance.mainThemePlaying = true;
        }
    }

    public void Play ()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Options ()
    {
        Debug.Log("OPTIONS");
    }

    public void Quit ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
