using UnityEngine;
using TMPro;
public class CastleUI : MinhMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI castleHealth;
    [SerializeField] protected CastleData castleData;
    public static CastleUI Instance { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        UpdateCastleHealthUI();
    }
    private void LoadCastleHealth()
    {
        if (this.castleHealth != null) return;
        this.castleHealth = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " LoadCastleHealth", gameObject);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCastleData();
        this.LoadCastleHealth();
    }
    protected virtual void LoadCastleData()
    {
        if (this.castleData != null) return;
        string resPath = "Caslte/CaslteHealth";
        this.castleData = Resources.Load<CastleData>(resPath);
        Debug.LogWarning(transform.name + ": LoadCastleData " + resPath, gameObject);
    }
    public virtual void UpdateCastleHealthUI()
    {
        castleHealth.text = castleData.currentHP.ToString();
    }

}
