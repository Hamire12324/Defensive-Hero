using UnityEngine;

public class DieEnemy : MinhMonoBehaviour
{
    public ObjectCtrl objectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectCtrl();
    }
    protected virtual void LoadObjectCtrl()
    {
        if (objectCtrl != null) return;
        objectCtrl = transform.parent.GetComponent<ObjectCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    public void DespawnFromAnimation()
    {
        objectCtrl.Despawn.DespawnObject();
    }
}
