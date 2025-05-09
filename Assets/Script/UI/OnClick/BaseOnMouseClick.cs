using UnityEngine;

public class BaseOnMouseClick : MinhMonoBehaviour
{
    protected void OnMouseDown()
    {
        this.OnMouseClickDown();
    }
    protected virtual void OnMouseClickDown()
    {
        //for override
    }
}
