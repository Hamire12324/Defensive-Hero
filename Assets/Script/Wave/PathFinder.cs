using UnityEngine;
using System.Collections.Generic;
public class PathFinder : MinhMonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] public float originalSpeed = 2;
    [SerializeField] public float currentSpeed = 2;
    private int currentWayPointIndex = 0;
    private void Update()
    {
        MoveAlongPath();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        ResetPath();
    }
    protected virtual void MoveAlongPath()
    {
        if (waypoints == null || currentWayPointIndex >= waypoints.Count) return;

        Transform parentTransform = transform.parent;
        if (parentTransform == null) return;

        parentTransform.position = Vector3.MoveTowards(
            parentTransform.position,
            waypoints[currentWayPointIndex].position,
            currentSpeed * Time.deltaTime
        );

        if (Vector3.Distance(parentTransform.position, waypoints[currentWayPointIndex].position) < 0.1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Count)
            {
                Despawn();
                CastleUI.Instance.UpdateCastleHealthUI();
            }
        }
    }
    protected virtual void ResetPath()
    {
        if (waypoints == null || waypoints.Count == 0) return;

        currentWayPointIndex = 0;
        transform.parent.position = waypoints[0].position;
    }
    public virtual void SetPath(List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
        transform.position = waypoints[0].position;
    }
    public virtual void SetMoveSpeed(float speed)
    {
        this.currentSpeed = speed;
    }
    protected virtual void Despawn()
    {
        Destroy(gameObject);
    }
}
