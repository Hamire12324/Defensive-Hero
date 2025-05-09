using UnityEngine;

public class GameCtrl : MinhMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;
    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        GameCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
    }
    protected virtual void LoadMainCamera()
    {
        if (mainCamera != null) return;
        mainCamera = Camera.main;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
}
