using UnityEngine;

public class HeroSpawner : Spawner
{
    private static HeroSpawner instance;
    public static HeroSpawner Instance => instance;
    public static string heroOne = "Hero_1";
    protected override void Awake()
    {
        base.Awake();
        if (HeroSpawner.instance != null) Debug.LogError("Only 1 HeroSpawner allow to exist");
        HeroSpawner.instance = this;
    }
}
