using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected Rigidbody2D rb;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }
    protected virtual void LoadRigibody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent == this.bulletCtrl.Shooter)
        {
            Debug.Log("[BulletImpact] Collision with shooter detected – Ignored", this.gameObject);
            return;
        }

        this.bulletCtrl.DamageSender.Send(other.transform);
        this.bulletCtrl.BulletFly.SetTarget(null);
    }
}
