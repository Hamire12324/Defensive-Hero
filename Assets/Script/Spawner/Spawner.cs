using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Spawner : MinhMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnCount;
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabsObjs = transform.Find("Prefabs");
        foreach(Transform prefab in prefabsObjs)
        {
            this.prefabs.Add(prefab);
        }
        Debug.LogWarning(transform.name + "LoadPrefabs", gameObject);
        this.HidePrefabs();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + "LoadHolder", gameObject);
    }
    public virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefabs = GetPrefabByName(prefabName);
        if (prefabs == null) return null;
        return this.Spawn(prefabs, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefabs = GetObjFromPool(prefab);
        spawnPos.z = 0f;
        newPrefabs.SetPositionAndRotation(spawnPos, rotation);
        newPrefabs.SetParent(this.holder);
        spawnCount++;
        return newPrefabs;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName) return prefab;
        }
        return null;
    }
    public virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        if(this.poolObjs.Contains(obj)) return;
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnCount--;
    }
}
