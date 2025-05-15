using UnityEngine;

public class GoleManager : MinhMonoBehaviour
{
    private static GoleManager instance;
    public static GoleManager Instance => instance;

    public GoldData goldData;
    protected override void Awake()
    {
        base.Awake();
        goldData.Reset();
        if (GoleManager.instance != null) Debug.LogError("Only 1 GoldManager allow to exist");
        GoleManager.instance = this;
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGoldData();
    }
    protected virtual void LoadGoldData()
    {
        if (goldData != null) return;
        string resPath = "Gold/"+ transform.name;
        this.goldData = Resources.Load<GoldData>(resPath);
        Debug.LogWarning(transform.name + ": LoadGoldData " + resPath, gameObject);
    }
    public void AddGold(int amount)
    {
        goldData.goldCurrent += amount;
        Debug.Log("AddGold: " + amount + " → Sum: " + goldData.goldCurrent);
    }

    public bool SpendGold(int amount)
    {
        if (goldData.goldCurrent >= amount)
        {
            goldData.goldCurrent -= amount;
            Debug.Log("Deduct: " + amount + " → remain: " + goldData.goldCurrent);
            return true;
        }
        else
        {
            Debug.Log("No Enough Gold!");
            return false;
        }
    }
}
