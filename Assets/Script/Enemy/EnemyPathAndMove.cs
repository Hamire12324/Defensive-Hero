using UnityEngine;

public class EnemyPathAndMove : PathFinder
{
    [SerializeField] private EnemyCtrl enemyCtrl;
    [SerializeField] private ObjectCtrl objectCtrl;

    [Header("Slow Effect")]
    private float slowDuration = 0f;
    private float savedOriginalSpeed;

    protected override void OnEnable()
    {
        base.OnEnable();
        SetMoveSpeed(originalSpeed);
        savedOriginalSpeed = currentSpeed;
    }

    private void Update()
    {
        base.MoveAlongPath();
        UpdateSlowEffect();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();

        if (enemyCtrl == null)
        {
            enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
            Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
        }

        if (objectCtrl == null)
        {
            objectCtrl = transform.parent.GetComponent<ObjectCtrl>();
            Debug.Log(transform.name + ": LoadObjectCtrl", gameObject);
        }
    }
    private void UpdateSlowEffect()
    {
        if (slowDuration > 0)
        {
            slowDuration -= Time.deltaTime;
            if (slowDuration <= 0)
            {
                SetMoveSpeed(savedOriginalSpeed);
            }
        }
    }

    public void ApplySlow(float slowPercent, float duration)
    {
        float slowedSpeed = originalSpeed * (1f - slowPercent);
        SetMoveSpeed(slowedSpeed);
        slowDuration = duration;
    }
    public void StopMovingOnDeath()
    {
        SetMoveSpeed(0f);
    }
    protected override void Despawn()
    {
        if (objectCtrl != null && objectCtrl.HpBar != null)
        {
            objectCtrl.HpBar.Despawn();
        }

        EnemySpawner.Instance.Despawn(transform.parent);
        CaslteManager.Instance.DeductCaslteHealth(1);
    }
}
