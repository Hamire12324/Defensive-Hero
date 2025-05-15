using UnityEngine;

public class AbilityDragon: MinhMonoBehaviour
{
    [SerializeField] private SilenceSkill silenceSkill;
    [SerializeField] private float castInterval = 5f;
    private float castTimer = 0f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSilenceSkill();
    }

    protected virtual void LoadSilenceSkill()
    {
        if (silenceSkill != null) return;
        silenceSkill = GetComponentInChildren<SilenceSkill>();
    }

    private void Update()
    {
        castTimer += Time.deltaTime;
        if (castTimer >= castInterval)
        {
            silenceSkill.CastSilenceSkill();
            castTimer = 0f;
        }
    }
}
