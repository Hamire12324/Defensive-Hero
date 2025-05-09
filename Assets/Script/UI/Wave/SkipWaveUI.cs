using UnityEngine;
using UnityEngine.UI;

public class SkipWaveUI : MinhMonoBehaviour
{
    [SerializeField] private Image countdownImage;
    [SerializeField] private Button skipButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCountdownImage();
        this.LoadSkipButton();
    }
    protected virtual void LoadCountdownImage()
    {
        if (this.countdownImage != null) return;
        this.countdownImage = transform.Find("CountdownImage").GetComponent<Image>();
        Debug.LogWarning(transform.name + "LoadCountdownImage", gameObject);
    }
    protected virtual void LoadSkipButton()
    {
        if (this.skipButton != null) return;
        this.skipButton = transform.Find("SkipWaveButton").GetComponent<Button>();
        Debug.LogWarning(transform.name + "LoadSkipButton", gameObject);
    }
    public void ShowCountdown(float current, float max)
    {
        gameObject.SetActive(true);
        countdownImage.fillAmount = Mathf.Clamp01(current / max);
    }

    public void ClearCountdown()
    {
        countdownImage.fillAmount = 0f;
    }

    public void ShowSkipButton(bool show)
    {
        skipButton.gameObject.SetActive(show);
    }
}
