using UnityEngine;
using UnityEngine.UI;

public class HeroPlacer : MinhMonoBehaviour
{
    [SerializeField] private int cost = 100;
    [SerializeField] protected Transform heroListButton;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroListButton();
    }
    protected virtual void LoadHeroListButton()
    {
        if (this.heroListButton != null) return;
        this.heroListButton = GetComponentInChildren<Transform>();
    }
    public void ShowHeroListUI()
    {
        foreach(Transform t in heroListButton)
        {
            t.gameObject.SetActive(true);
        }
    }
    public void SelectAndPlaceHero(int index)
    {
        string heroId = $"Hero_{index}";
        HeroSpawner.heroOne = heroId;
        Debug.Log("Selected hero: " + heroId);
        PlaceHero();
    }


    public void PlaceHero()
    {
        if (!GoleManager.Instance.SpendGold(cost)) return;
        GoldUI.Instance?.UpdateGoldUI();
        Vector3 pos = transform.position;
        Transform hero = HeroSpawner.Instance.Spawn(HeroSpawner.heroOne, pos, Quaternion.identity);
        hero.gameObject.SetActive(true);

        HeroCtrl heroCtrl = hero.GetComponent<HeroCtrl>();
        if (heroCtrl != null)
        {
            heroCtrl.SetPlacer(this);
        }

        Button placeButton = GetComponentInChildren<Button>();
        if (placeButton != null)
        {
            placeButton.gameObject.SetActive(false);
        }
    }
}
