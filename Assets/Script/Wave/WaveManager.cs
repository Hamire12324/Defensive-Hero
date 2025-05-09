using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MinhMonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private WaveUIManager waveUIManager;

    private int currentWaveIndex = 0;
    private bool playerRequestedNextWave = false;
    private bool isWaitingForNextWave = false;

    protected override void Start()
    {
        waveUIManager.ShowStartWaveButton(true);
        waveUIManager.ClearCountdown();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaveUIManager();
    }

    private void LoadWaveUIManager()
    {
        if (waveUIManager != null) return;
        waveUIManager = FindAnyObjectByType<WaveUIManager>();
        Debug.LogWarning(transform.name + ": WaveUIManager loaded automatically", this);
    }

    public void StartNextWave()
    {
        if (isWaitingForNextWave)
        {
            playerRequestedNextWave = true;
        }
        else
        {
            waveUIManager.ShowStartWaveButton(false);
            StartCoroutine(HandleWave());
        }
    }

    private IEnumerator HandleWave()
    {
        if (currentWaveIndex >= waveConfigs.Count)
            yield break;

        WaveConfigSO currentWave = waveConfigs[currentWaveIndex];
        waveUIManager.UpdateWaveText("Wave " + (currentWaveIndex + 1) + "/" + waveConfigs.Count);
        yield return StartCoroutine(EnemySpawner.Instance.SpawnEnemiesInWave(currentWave));
        currentWaveIndex++;

        float timeToWait = currentWave.WaveInterval;
        float timer = 0f;
        playerRequestedNextWave = false;
        isWaitingForNextWave = true;

        waveUIManager.ShowStartWaveButton(true);

        while (timer < timeToWait && !playerRequestedNextWave)
        {
            timer += Time.deltaTime;
            waveUIManager.UpdateCountdown(timeToWait - timer, timeToWait);
            yield return null;
        }

        isWaitingForNextWave = false;
        waveUIManager.ClearCountdown();
        waveUIManager.ShowStartWaveButton(false);
        StartCoroutine(HandleWave());
    }
}
