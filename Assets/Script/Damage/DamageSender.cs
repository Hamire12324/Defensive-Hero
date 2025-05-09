using UnityEngine;

public class DamageSender : MinhMonoBehaviour
{
    [SerializeField] protected double damage = 1;
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(this.damage);
    }
    public virtual void SetDamage(double damage)
    {
        this.damage = damage;
    }
    public virtual double GetDamage()
    {
        return this.damage;
    }
}
