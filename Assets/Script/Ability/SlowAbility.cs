using UnityEngine;

public class SlowAbility : MonoBehaviour
{
    public float slowRate = 0.5f;
    public float slowDuration = 2f;

    public void Apply(GameObject target)
    {
        var moveSpeed = target.GetComponent<EnemyPathAndMove>();
        if (moveSpeed != null)
        {
            moveSpeed.ApplySlow(slowRate, slowDuration);
        }
    }
}
