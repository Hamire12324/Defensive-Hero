using UnityEngine;

public abstract class ObjectShoot: MinhMonoBehaviour
{
    [Header("Object Shoot")]
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected float time = 0f;
    [SerializeField] protected bool isShooting;
    protected virtual void Update()
    {
        this.IsShooting();
    }
    protected virtual void Shooting()
    {
        this.time += Time.deltaTime;
        if (!this.isShooting) return;
        if (this.time < shootDelay) return;
        this.time = 0;

        Vector3 pos = transform.position;
        Quaternion rotation = transform.rotation;
        Transform newBullet = BulletSpawn.Instance.Spawn(BulletSpawn.bulletOne, pos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
    }
    public virtual void SetDame(int dame)
    {
        this.damage = dame;
    }
    public virtual void SetDelay(int shootDelay)
    {
        this.shootDelay = shootDelay;
    }
    protected abstract bool IsShooting();
}
