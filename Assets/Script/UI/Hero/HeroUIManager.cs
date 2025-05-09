using UnityEngine;
using UnityEngine.UI;
public class HeroUIManager : MinhMonoBehaviour
{
    [SerializeField] HeroCtrl heroCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroCtrl();
    }
    protected virtual void LoadHeroCtrl()
    {
        if (this.heroCtrl != null) return;
        this.heroCtrl = transform.parent.GetComponent<HeroCtrl>();
        Debug.LogWarning(transform.name + "LoadHeroCtrl" + gameObject.name);
    }

    public void DespawnHero()
    {
        foreach (Transform child in heroCtrl.HeroPlacer.transform)
        {
            child.gameObject.SetActive(false);
        }
        heroCtrl.HeroPlacer.gameObject.SetActive(true);
        this.CloseUI();
        heroCtrl.Despawn.DespawnObject();
        Debug.Log("Xoá (despawn) Hero!");
    }

    public void CloseUI()
    {
        foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
        Debug.Log("Đóng giao diện Hero UI!");
    }
}
