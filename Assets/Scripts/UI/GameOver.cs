using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        AudioManager.instance.StopPlaying(gameManager.soundtrack);
        SceneManager.LoadScene("MainMenu");
    }
}
