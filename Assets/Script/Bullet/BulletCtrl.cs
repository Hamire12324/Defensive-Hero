using UnityEngine;

public class BulletCtrl : MinhMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;
    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;
    [SerializeField] protected BulletTargetEnemy bulletTargetEnemy;
    public BulletTargetEnemy BulletTargetEnemy => bulletTargetEnemy;
    [SerializeField] protected BulletFly bulletFly;
    public BulletFly BulletFly => bulletFly;
    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadBulletTargetEnemy();
        this.LoadBulletFly();
        this.LoadObjLookAtTarget();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }
    protected virtual void LoadBulletTargetEnemy()
    {
        if (this.bulletTargetEnemy != null) return;
        this.bulletTargetEnemy = transform.GetComponentInChildren<BulletTargetEnemy>();
        Debug.Log(transform.name + ": LoadBulletTargetEnemy", gameObject);
    }
    protected virtual void LoadBulletFly()
    {
        if (this.bulletFly != null) return;
        this.bulletFly = transform.GetComponentInChildren<BulletFly>();
        Debug.Log(transform.name + ": LoadBulletFly", gameObject);
    }
    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = transform.GetComponentInChildren<ObjLookAtTarget>();
        Debug.Log(transform.name + ": LoadObjLookAtTarget", gameObject);
    }
    public virtual void SetShotter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
