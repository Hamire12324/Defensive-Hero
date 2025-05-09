using UnityEngine;

public class SilenceSkill : MinhMonoBehaviour
{
    [SerializeField] private float silenceRadius = 5f;
    [SerializeField] private float disableDuration = 3f;

    public void CastSilenceSkill()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, silenceRadius);

        foreach (Collider2D col in colliders)
        {
            if (!col.CompareTag("Hero") || !col.gameObject.activeInHierarchy) continue;

            HeroController heroController = col.transform.parent.GetComponentInChildren<HeroController>();
            if (heroController != null)
            {
                heroController.SetSilence(true, disableDuration);
                Debug.Log("Dragon cast 1 silence");

            }
        }

        Debug.Log("Dragon cast silence");
    }
}
