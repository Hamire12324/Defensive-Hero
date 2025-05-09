using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
