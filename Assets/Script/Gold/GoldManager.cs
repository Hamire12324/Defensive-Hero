using UnityEngine;

public class GoleManager : MinhMonoBehaviour
{
    private static GoleManager instance;
    public static GoleManager Instance => instance;

    public GoldData goldData;
    protected override void Awake()
    {
        base.Awake();
        if(GoleManager.instance != null) Debug.LogError("Only 1 GoldManager allow to exist");
        GoleManager.instance = this;
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
        goldData.gold += amount;
        Debug.Log("AddGold: " + amount + " → Sum: " + goldData.gold);
    }

    public bool SpendGold(int amount)
    {
        if (goldData.gold >= amount)
        {
            goldData.gold -= amount;
            Debug.Log("Deduct: " + amount + " → remain: " + goldData.gold);
            return true;
        }
        else
        {
            Debug.Log("No Enough Gold!");
            return false;
        }
    }
}
