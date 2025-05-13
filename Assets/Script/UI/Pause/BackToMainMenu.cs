using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : BaseButton
{
    [SerializeField] protected string mainMenuSceneName = "MainMenu";

    protected override void OnClick()
    {
        Debug.Log("Returning to Main Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
