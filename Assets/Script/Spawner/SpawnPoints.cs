using UnityEngine;
using System.Collections.Generic;
public class SpawnPoints : MinhMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach(Transform point in transform)
        {
            points.Add(point);
        }
    }
}
