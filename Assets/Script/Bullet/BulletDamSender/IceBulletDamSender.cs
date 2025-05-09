using UnityEngine;

public class IceBulletDamSender : BulletDamSender
{
    [SerializeField] private float slowAmount = 0.5f;
    [SerializeField] private float slowDuration = 2f;

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        Transform enemyRoot = damageReceiver.transform.parent;
        if (enemyRoot != null)
        {
            EnemyPathAndMove moveSpeed = enemyRoot.GetComponentInChildren<EnemyPathAndMove>();
            if (moveSpeed != null)
            {
                moveSpeed.ApplySlow(slowAmount, slowDuration);
                Debug.Log("Slowed");
            }
        }
    }
}
