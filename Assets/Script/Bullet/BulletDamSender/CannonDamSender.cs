using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CannonDamSender : BulletDamSender
{
    [Header("AOE Settings")]
    [SerializeField] private float aoeRadius = 2f;
    [SerializeField] private double aoeDamageMultiplier = 0.5;

    public override void Send(DamageReceiver primaryDamageReceiver)
    {
        base.Send(primaryDamageReceiver);

        ApplyAoEDamage(primaryDamageReceiver);

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        CreateImpactFX(hitPos, hitRot);

        DestroyBullet();
    }

    private void ApplyAoEDamage(DamageReceiver primaryDamageReceiver)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, aoeRadius);
        Debug.Log("Số đối tượng bị quét: " + colliders.Length);

        foreach (Collider2D collider in colliders)
        {
            DamageReceiver damageReceiver = collider.GetComponentInChildren<DamageReceiver>();
            if (damageReceiver == null) continue;

            if (damageReceiver == primaryDamageReceiver) continue;

            double aoeDamage = this.damage * aoeDamageMultiplier;
            damageReceiver.DeductHp(aoeDamage);

            Debug.Log($"AOE Damage applied to {collider.name} : {aoeDamage}");
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, aoeRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);

        Handles.color = Color.white;
        Handles.Label(
            transform.position + Vector3.up * (aoeRadius + 0.5f),
            $"AOE Radius: {aoeRadius}"
        );
    }
#endif
}
