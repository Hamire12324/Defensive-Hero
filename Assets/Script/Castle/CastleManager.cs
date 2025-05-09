using UnityEngine;

public class CaslteManager : MinhMonoBehaviour
{
    private static CaslteManager instance;
    public static CaslteManager Instance => instance;

    public CastleData castleData;
    protected override void Awake()
    {
        base.Awake();
        if (CaslteManager.instance != null) Debug.LogError("Only 1 CastleManager allow to exist");
        CaslteManager.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCastleData();
    }
    protected virtual void LoadCastleData()
    {
        if (this.castleData != null) return;
        string resPath = "Caslte/CaslteHealth";
        this.castleData = Resources.Load<CastleData>(resPath);
        Debug.LogWarning(transform.name + ": LoadCastleData " + resPath, gameObject);
    }
    public void AddCaslteHealth(int amount)
    {
        castleData.currentHP += amount;
        Debug.Log("AddGold: " + amount + " → Sum: " + castleData.currentHP);
    }

    public bool DeductCaslteHealth(int amount)
    {
        if (castleData.currentHP >= amount)
        {
            castleData.currentHP -= amount;
            Debug.Log("Deduct: " + amount + " → remain: " + castleData.currentHP);
            return true;
        }
        else
        {
            Debug.Log("Defeat!");
            return false;
        }
    }
}
