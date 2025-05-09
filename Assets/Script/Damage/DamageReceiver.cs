using UnityEngine;

public abstract class DamageReceiver : MinhMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected double currentHp = 2;
    [SerializeField] protected double hpMax = 2;
    [SerializeField] protected bool isDead;
    public double CurrentHp => currentHp;
    public double HPMax => hpMax;
    protected override void OnEnable()
    {
        this.Reborn();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    public virtual void Reborn()
    {
        this.currentHp = hpMax;
        isDead = false;
    }
    public virtual void AddHp(double addHp)
    {
        if (isDead) return;
        this.currentHp += addHp;
        if (this.currentHp > this.hpMax) this.currentHp = this.hpMax;
    }
    public virtual void DeductHp(double deductHp)
    {
        if (isDead) return;
        this.currentHp -= deductHp;
        if (this.currentHp < 0) this.currentHp = 0;
        this.CheckIsDead();
    }
    public virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    public virtual bool IsDead()
    {
        return this.currentHp <= 0;
    }
    public virtual void SetHPMax(double hpMax)
    {
        this.hpMax = hpMax;
    }
    public abstract void OnDead();
}
