using UnityEngine;

public abstract class ObjectCtrl : MinhMonoBehaviour
{
    [Header("Object Ctrl")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    [SerializeField] protected ObjectSO objectSO;
    public ObjectSO Object => objectSO;
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    [SerializeField] protected HpBar hpBar;
    public HpBar HpBar => hpBar;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadSpawner();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": LoadDespawn", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.objectSO != null) return;
        string resPath = "Object/" + this.GetObjectTypeString() + "/" + transform.name;
        this.objectSO = Resources.Load<ObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadSO " + resPath, gameObject);
    }
    public virtual void SetHpBar(HpBar hpBar)
    {
        this.hpBar = hpBar;
    }
    protected abstract string GetObjectTypeString();
}
