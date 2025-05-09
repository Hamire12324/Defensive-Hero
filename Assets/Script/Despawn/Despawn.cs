using UnityEngine;

public abstract class Despawn : MinhMonoBehaviour
{
    private void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }
    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}
