using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : Spawner
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);

        return newEnemy;
    }
    public IEnumerator SpawnEnemiesInWave(WaveConfigSO waveConfig)
    {
        List<GameObject> enemies = waveConfig.EnemyPrefabs;
        List<Transform> waypoints = waveConfig.GetWaypoints();

        foreach (GameObject enemyPrefab in enemies)
        {
            Transform enemyTransform = Spawn(enemyPrefab.transform, waypoints[0].position, Quaternion.identity);
            GameObject newEnemy = enemyTransform.gameObject;
            newEnemy.SetActive(true);
            PathFinder pathFinder = newEnemy.GetComponentInChildren<PathFinder>();
            if (pathFinder != null)
            {
                pathFinder.SetPath(waypoints);
            }
            yield return new WaitForSeconds(waveConfig.TimeBetweenEnemySpawns);
        }
    }
    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        if (newEnemy == null)
        {
            Debug.LogError("newEnemy is null!");
            return;
        }

        ObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ObjectCtrl>();
        if (newEnemyCtrl == null)
        {
            Debug.LogError("ObjectCtrl not found on: " + newEnemy.name);
            return;
        }

        if (HPBarSpawner.Instance == null)
        {
            Debug.LogError("HPBarSpawner.Instance is null!");
            return;
        }

        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBarSmall, newEnemy.position, Quaternion.identity);
        if (newHpBar == null)
        {
            Debug.LogError("HPBar could not be spawned!");
            return;
        }

        HpBar hpBar = newHpBar.GetComponent<HpBar>();
        if (hpBar == null)
        {
            Debug.LogError("HPBar component missing on: " + newHpBar.name);
            return;
        }
        newEnemyCtrl.SetHpBar(hpBar);
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);
        newHpBar.gameObject.SetActive(true);
    }

}
