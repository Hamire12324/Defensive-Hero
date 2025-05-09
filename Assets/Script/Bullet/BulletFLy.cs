using UnityEngine;

public class BulletFly : ObjectFly
{
    [SerializeField] Transform target;
    [SerializeField] BulletCtrl bulletCtrl;
    protected override void Update()
    {
        if (target == null || !target.gameObject || !target.gameObject.activeInHierarchy)
        {
            if (bulletCtrl != null && bulletCtrl.BulletDespawn != null)
            {
                bulletCtrl.BulletDespawn.DespawnObject();
            }
            return;
        }

        if (bulletCtrl.ObjLookAtTarget != null)
        {
            bulletCtrl.ObjLookAtTarget.SetTargetRotation(target);
        }

        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 parentPos = transform.parent.position;
        parentPos.z = 0f;

        transform.parent.position = parentPos + direction * speed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 50f;
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
