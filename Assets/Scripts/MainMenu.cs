using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "TestScene";

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
