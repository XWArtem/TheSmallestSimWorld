using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ItemWeapon : ItemBase
{
    public int DamagePerAttack;
    public float AttackRange;


    public ItemWeapon(int id, string name, int cost, int damagePerAttack, float attackRange, string spriteName) : base(id, name, cost, spriteName)
    {
        ID = id;
        Name = name;
        DamagePerAttack = 1;
        Cost = cost;
        DamagePerAttack = damagePerAttack;
        AttackRange = attackRange;
        SpriteName = spriteName;
    }
}
