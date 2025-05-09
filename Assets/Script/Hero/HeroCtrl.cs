using UnityEngine;

public class HeroCtrl : ObjectCtrl
{
    [Header(("HeroCtrl"))]
    [SerializeField] protected HeroPlacer heroPlacer;
    public HeroPlacer HeroPlacer => heroPlacer;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
    public void SetPlacer(HeroPlacer heroPlacer)
    {
        this.heroPlacer = heroPlacer;
    }
}
