using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SO/Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("Enemy Settings")]
    [SerializeField] private List<GameObject> enemyPrefabs;

    [Header("Path Settings")]
    [SerializeField] private Transform pathPrefab;

    [Header("Timing Settings")]
    [SerializeField] private float timeBetweenEnemySpawns = 1f;
    [SerializeField] private float waveInterval = 2f;

    public List<GameObject> EnemyPrefabs => enemyPrefabs;
    public Transform PathPrefab => pathPrefab;
    public float TimeBetweenEnemySpawns => timeBetweenEnemySpawns;
    public float WaveInterval => waveInterval;
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

}
