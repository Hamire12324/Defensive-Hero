using UnityEngine;

public abstract class Ability : MinhMonoBehaviour
{
    public float cooldown = 1f;
    protected float lastUseTime = -999f;

    public virtual bool CanUse()
    {
        return Time.time - lastUseTime >= cooldown;
    }

    public void TryUse(GameObject target)
    {
        if (CanUse())
        {
            Use(target);
            lastUseTime = Time.time;
        }
    }

    protected abstract void Use(GameObject target);
}
