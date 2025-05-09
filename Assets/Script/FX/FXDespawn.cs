using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FXDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
