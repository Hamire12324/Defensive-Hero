using UnityEngine;

public class HeroDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        HeroSpawner.Instance.Despawn(transform.parent);
    }
}
