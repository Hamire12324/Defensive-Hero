using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class BulletSpawn : Spawner
{
    private static BulletSpawn instance;
    public static BulletSpawn Instance => instance;
    public static string bulletOne = "Bullet_1";
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawn.instance != null) Debug.LogError("Only 1 BulletSpawn allow to exist");
        BulletSpawn.instance = this;
    }
}
