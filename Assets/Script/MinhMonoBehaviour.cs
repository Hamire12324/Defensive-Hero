using UnityEngine;

public class MinhMonoBehaviour : MonoBehaviour
{
    protected virtual void Start()
    {
        //override
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {

    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void OnEnable()
    {

    }
}
