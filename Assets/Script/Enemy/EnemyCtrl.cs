using UnityEngine;

public class EnemyCtrl : ObjectCtrl
{
    [Header("Enemy Ctrl")]
    [SerializeField] protected EnemyPathAndMove enemyPathAndMove;
    public EnemyPathAndMove EnemyPathAndMove => enemyPathAndMove;
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn => enemyDespawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPathFinder();
        this.LoadEnemyDespawn();
    }
    protected virtual void LoadEnemyPathFinder()
    {
        if (this.enemyPathAndMove != null) return;
        enemyPathAndMove = GetComponentInChildren<EnemyPathAndMove>();
        Debug.LogWarning(transform.name + ": LoadEnemyPathFinder", gameObject);
    }
    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        enemyDespawn = GetComponentInChildren<EnemyDespawn>();
        Debug.LogWarning(transform.name + ": LoadEnemyDespawn", gameObject);
    }
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
