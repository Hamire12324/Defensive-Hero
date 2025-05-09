using UnityEngine;

public class HeroOnMouseClick : BaseOnMouseClick
{   
    protected override void OnMouseClickDown()
    {
        Transform parent = transform.parent;
        if (parent == null) return;

        Transform heroUI = parent.Find("HeroUI");
        if (heroUI == null) return;

        foreach (Transform child in heroUI)
        {
            child.gameObject.SetActive(true);
        }
    }
}
