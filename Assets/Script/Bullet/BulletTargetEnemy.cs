using UnityEngine;

public class BulletTargetEnemy : TargetObject
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private BulletCtrl bulletCtrl;
    private Transform closestEnemy;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Transform target = GetClosestEnemy();
        bulletCtrl.BulletFly.SetTarget(target);
    }


    protected override void ResetValue()
    {
        base.ResetValue();
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent?.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    public Transform GetClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);

        Debug.Log("Enemies found: " + enemies.Length);

        if (enemies.Length == 0) return null;

        float minSqrDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach (Collider2D enemy in enemies)
        {
            Transform enemyTransform = enemy.transform;
            Transform parent = enemyTransform.parent;
            if (parent == null || !parent.gameObject.activeSelf) continue;

            Transform model = parent.Find("Model");
            if (model != null)
            {
                Animator animator = model.GetComponent<Animator>();
                if (animator != null && animator.GetBool("IsDead")) continue;
            }

            float sqrDistance = (enemyTransform.position - transform.position).sqrMagnitude;
            if (sqrDistance < minSqrDistance)
            {
                minSqrDistance = sqrDistance;
                closestEnemy = enemyTransform;
            }
        }
        return closestEnemy;
    }

}
