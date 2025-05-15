using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            if (WaveManager.Instance.IsLastWave())
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
            }
        }
        GoleManager.Instance.AddGold(50);
        GoldUI.Instance.UpdateGoldUI();
    }
}
