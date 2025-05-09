using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        BulletSpawn.Instance.Despawn(transform.parent);
    }
}
