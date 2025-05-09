using UnityEngine;

public class BulletDamSender : DamageSender
{
    [SerializeField] BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;

        this.CreateImpactFX(hitPos, hitRot);

        this.DestroyBullet();
    }
    protected virtual void CreateImpactFX(Vector3 hitPos, Quaternion hitRot)
    {
        string fxName = this.GetImpactFX();
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.lighting;
    }
    public virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
