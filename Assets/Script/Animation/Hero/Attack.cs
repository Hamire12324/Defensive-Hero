using UnityEngine;

public class Attack : MinhMonoBehaviour
{
    [SerializeField] private HeroCtrl heroCtrl;
    [SerializeField] protected double dameBonus;
    [SerializeField] protected double addDame = 20;
    [SerializeField] protected int cost = 250;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (heroCtrl == null)
        {
            heroCtrl = transform.parent.GetComponent<HeroCtrl>();
            Debug.Log(transform.name + ": LoadHeroCtrl", gameObject);
        }
    }
    public void SpawnBulletByAnimation()
    {
        Vector3 pos = transform.position;
        Quaternion rotation = transform.rotation;

        string heroName = transform.parent.name;
        string bulletName = heroName.Replace("Hero", "Bullet");

        Transform newBullet = BulletSpawn.Instance.Spawn(bulletName, pos, rotation);
        if (newBullet == null) return;

        DamageSender dmgSender = newBullet.GetComponentInChildren<DamageSender>();
        if (dmgSender != null)
        {
            double baseDamage = 0;

            baseDamage = dmgSender.GetDamage();

            double bonus = dameBonus;
            double totalDamage = baseDamage + bonus;
            dmgSender.SetDamage(totalDamage);

            Debug.Log($"Spawn Bullet with Damage = {baseDamage} + {bonus} = {totalDamage}");
        }

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
    }
    public void UpdateHero()
    {
        if (!GoleManager.Instance.SpendGold(cost)) return;
        GoldUI.Instance?.UpdateGoldUI();
        dameBonus += addDame;
        Debug.Log($"Updated damage: dameBonus = {dameBonus}, addDame = {addDame}");
    }


}
