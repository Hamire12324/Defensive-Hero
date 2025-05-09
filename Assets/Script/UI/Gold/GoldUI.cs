using TMPro;
using UnityEngine;
public class GoldUI : MinhMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private GoldData goldData;
    public static GoldUI Instance { get; private set; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGoldText();
        this.LoadGoldData();
    }


    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        UpdateGoldUI();
    }
    private void LoadGoldText()
    {
        if (this.goldText != null) return;
        this.goldText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " LoadGoldText", gameObject);
    }
    protected virtual void LoadGoldData()
    {
        if (goldData != null) return;
        string resPath = "Gold/GoldManager";
        this.goldData = Resources.Load<GoldData>(resPath);
        Debug.LogWarning(transform.name + ": LoadGoldData " + resPath, gameObject);
    }
    public void UpdateGoldUI()
    {
        if (goldText != null && goldData != null)
        {
            goldText.text = goldData.gold.ToString();
        }
    }
}
