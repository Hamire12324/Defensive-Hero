using UnityEngine;

public class ExitGame : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("Exiting game...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
