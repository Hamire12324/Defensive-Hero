using UnityEngine;

public class PauseManager : MinhMonoBehaviour
{
    private static PauseManager instance;
    public static PauseManager Instance => instance;

    [SerializeField] protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (PauseManager.instance != null) Debug.LogError("Only 1 PauseManager allow to exist");
        PauseManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();
    }
    public virtual void Toggle()
    {
        Debug.Log("Sussces Open");
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        Debug.Log("Opening Pause Menu");

        this.gameObject.SetActive(true);
        this.isOpen = true;

        Time.timeScale = 0f;
    }

    public virtual void Close()
    {
        Debug.Log("Closing Pause Menu");

        this.gameObject.SetActive(false);
        this.isOpen = false;

        Time.timeScale = 1f;
    }
}
