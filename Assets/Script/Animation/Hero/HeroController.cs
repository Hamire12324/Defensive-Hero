using UnityEngine;

public class HeroController : MinhMonoBehaviour
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Animator animator;

    private bool isSilenced = false;
    private float silenceTimer = 0f;

    protected override void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isSilenced)
        {
            silenceTimer -= Time.deltaTime;
            if (silenceTimer <= 0f)
            {
                isSilenced = false;
            }
        }

        if (HasEnemyInRange())
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isIdling", false);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isIdling", true);
        }
    }

    private bool HasEnemyInRange()
    {
        if (isSilenced) return false;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);
        return enemies.Length > 0;
    }

    public void SetSilence(bool silenced, float duration)
    {
        isSilenced = silenced;
        silenceTimer = duration;
    }
}
