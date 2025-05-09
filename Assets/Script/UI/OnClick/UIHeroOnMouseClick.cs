using UnityEngine;

public class UIHeroOnMouseClick : BaseOnMouseClick
{
    protected override void OnMouseClickDown()
    {
        base.OnMouseClickDown();
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
