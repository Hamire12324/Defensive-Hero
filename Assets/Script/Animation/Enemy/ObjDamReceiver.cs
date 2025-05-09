using UnityEngine;

public class ObjDamReceiver : DamageReceiver
{
    [SerializeField] protected ObjectCtrl objectCtrl;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Animator animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectCtrl();
        this.LoadEnemyCtrl();
        this.LoadAnimator();
    }

    protected virtual void LoadObjectCtrl()
    {
        if (objectCtrl != null) return;
        objectCtrl = transform.parent.GetComponent<ObjectCtrl>();
        this.hpMax = this.objectCtrl.Object.hpMax;
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl == null)
        {
            enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
            Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
        }
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        Transform model = objectCtrl.transform.Find("Model");
        if (model != null)
        {
            animator = model.GetComponent<Animator>();
            Debug.Log(transform.name + ": LoadAnimator", gameObject);
        }
    }
    public override void OnDead()
    {
        animator.SetBool("IsDead", true);
        enemyCtrl.EnemyPathAndMove.StopMovingOnDeath();
    }
}
