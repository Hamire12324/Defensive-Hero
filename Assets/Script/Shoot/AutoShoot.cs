using UnityEngine;

public class AutoShoot : ObjectShoot
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private bool isDisabled = false;
    private float disableTimer = 0f;

    protected override void Update()
    {
        base.Update();
        if (isDisabled)
        {
            disableTimer -= Time.deltaTime;
            if (disableTimer <= 0f)
            {
                isDisabled = false;
            }
        }
    }

    protected override bool IsShooting()
    {
        if (isDisabled) return false;
        isShooting = IsEnemyNearby();
        return this.isShooting;
    }

    private bool IsEnemyNearby()
    {
        return false;
    }
}
