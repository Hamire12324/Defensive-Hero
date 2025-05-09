using UnityEngine;

public class CritBulletDamSender : BulletDamSender
{
    [SerializeField] private double critChance = 0.3;
    [SerializeField] private double critMultiplier = 1.0;

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);

        if (IsCrit())
        {
            double critDamage = this.damage * critMultiplier;
            Debug.Log("Critical hit! Damage: " + critDamage);
            damageReceiver.DeductHp(critDamage);
        }
    }

    private bool IsCrit()
    {
        return Random.value < critChance;
    }
}
