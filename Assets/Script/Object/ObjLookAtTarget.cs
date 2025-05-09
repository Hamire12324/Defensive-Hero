using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtTarget : MinhMonoBehaviour
{
    [Header("Look At Target")]
    [SerializeField] protected Vector3 targetPosition;

    protected virtual void FixUpdate()
    {
        this.LootAtTarget();
    }

    protected virtual void LootAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        transform.parent.rotation = targetEuler;
    }

    public void SetTargetRotation(Transform target)
    {
        this.targetPosition = target.position;
    }
}
