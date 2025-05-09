using UnityEngine;

public class EnemyDamReceiver : ObjDamReceiver
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetDeadState();
    }
    public void ResetDeadState()
    {
        animator.SetBool("IsDead", false);
    }
}
