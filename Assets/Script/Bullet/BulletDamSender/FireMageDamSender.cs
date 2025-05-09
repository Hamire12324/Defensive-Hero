using UnityEngine;

public class FireMageDamSender : BulletDamSender
{
    [Header("Burn Effect")]
    [SerializeField] private float burnDuration = 3f;
    [SerializeField] private double burnDPS = 1.0;

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        ApplyBurnEffect(damageReceiver);
    }

    protected virtual void ApplyBurnEffect(DamageReceiver target)
    {
        BurnEffect burn = target.gameObject.GetComponent<BurnEffect>();
        if (burn == null) burn = target.gameObject.AddComponent<BurnEffect>();

        burn.Init(burnDPS, burnDuration);
    }

}
