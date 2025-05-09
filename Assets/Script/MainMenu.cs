using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void OpenOptions()
    {
        Debug.Log("Open Options");
    }

    public void ShowHowToPlay()
    {
        Debug.Log("Show How to Play");
    }

    public void ShowCredits()
    {
        Debug.Log("Show Credits");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
