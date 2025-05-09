using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected float disLimit = 20f;
    [SerializeField] protected float distance;
    [SerializeField] Transform mainCamera;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
    }
    protected virtual void LoadMainCamera()
    {
        if (mainCamera != null) return;
        this.mainCamera = Transform.FindAnyObjectByType<Camera>().transform;
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.position);
        if (distance < disLimit) return false;
        return true;
    }
}
