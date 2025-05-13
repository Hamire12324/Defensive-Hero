using UnityEngine;

public class ContinuePause : BaseButton
{
    protected override void OnClick()
    {
        PauseManager.Instance.Close();
    }
}
