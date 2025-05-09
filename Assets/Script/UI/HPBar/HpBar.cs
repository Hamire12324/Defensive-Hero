using UnityEngine;

public class HpBar : MinhMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ObjectCtrl objectCtrl;
    [SerializeField] protected SliderHP sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] public Spawner spawner;
    protected virtual void FixedUpdate()
    {
        this.HpShowing();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadSliderHp", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void HpShowing()
    {
        if (objectCtrl == null) return;
        bool isDead = this.objectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.Despawn();
            return;
        }
        double hp = this.objectCtrl.DamageReceiver.CurrentHp;
        double maxHp = this.objectCtrl.DamageReceiver.HPMax;
        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(maxHp);
    }
    public virtual void SetObjectCtrl(ObjectCtrl objectCtrl)
    {
        this.objectCtrl = objectCtrl;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
    public virtual void Despawn()
    {
        this.spawner.Despawn(transform);
    }

}
