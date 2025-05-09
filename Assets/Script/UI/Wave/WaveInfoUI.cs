using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveInfoUI : MinhMonoBehaviour
{
    [SerializeField] private Image waveImage;
    [SerializeField] private TextMeshProUGUI waveText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaveImage();
        this.LoadWaveText();
    }
    protected virtual void LoadWaveImage()
    {
        if (this.waveImage != null) return;
        this.waveImage = transform.Find("WaveImage").GetComponent<Image>();
        Debug.LogWarning(transform.name + "LoadWaveImage", gameObject);
    }
    protected virtual void LoadWaveText()
    {
        if (this.waveText != null) return;
        this.waveText = transform.Find("WaveText").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + "LoadWaveText", gameObject);
    }
    public void SetWaveSprite(Sprite sprite)
    {
        waveImage.sprite = sprite;
    }

    public void SetWaveText(string text)
    {
        waveText.text = text;
    }
}
