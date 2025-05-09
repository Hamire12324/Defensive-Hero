using UnityEngine;

public class WaveUIManager : MinhMonoBehaviour
{
    [SerializeField] private SkipWaveUI skipWaveUI;
    [SerializeField] private WaveInfoUI waveInfoUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (skipWaveUI == null)
            skipWaveUI = transform.Find("SkipWave").GetComponent<SkipWaveUI>();
        if (waveInfoUI == null)
            waveInfoUI = transform.Find("WaveInfo").GetComponent<WaveInfoUI>();
    }

    public void ShowCountdown(float current, float max)
    {
        if (skipWaveUI != null)
            skipWaveUI.ShowCountdown(current, max);
    }

    public void ClearCountdown()
    {
        if (skipWaveUI != null)
            skipWaveUI.ClearCountdown();
    }

    public void ShowStartWaveButton(bool show)
    {
        if (skipWaveUI != null)
            skipWaveUI.ShowSkipButton(show);
    }

    public void UpdateWaveText(string text)
    {
        if (waveInfoUI != null)
            waveInfoUI.SetWaveText(text);
    }

    public void UpdateWaveInfo(string text)
    {
        if (waveInfoUI != null)
            waveInfoUI.SetWaveText(text);
    }
    public void UpdateCountdown(float current, float max)
    {
        skipWaveUI?.ShowCountdown(current, max);
    }

}
