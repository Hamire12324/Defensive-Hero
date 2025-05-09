using UnityEngine;

public class BurnEffect : MinhMonoBehaviour
{
    [SerializeField] private double damagePerSecond;
    [SerializeField] private float duration;
    [SerializeField] private float timer;
    [SerializeField] private DamageReceiver damageReceiver;

    public void Init(double dps, float duration)
    {
        this.damagePerSecond = dps;
        this.duration = duration;
        this.timer = 0f;
        this.damageReceiver = GetComponent<DamageReceiver>();
    }

    private void Update()
    {
        if (damageReceiver == null) return;

        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(this);
            return;
        }

        damageReceiver.DeductHp(damagePerSecond * Time.deltaTime);
    }
}
