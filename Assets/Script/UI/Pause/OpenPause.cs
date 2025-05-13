using UnityEngine;

public class OpenPause : BaseButton
{
    protected override void OnClick()
    {
        PauseManager.Instance.Toggle();
    }
}
