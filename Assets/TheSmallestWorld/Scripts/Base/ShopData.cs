using System.Collections.Generic;

public class ShopData
{
    public readonly List<ItemBase> Items = new List<ItemBase>()
    {
        { new ItemWeapon(0, "Axe", 140, 5, 2, "Axe") },
        { new ItemWeapon(1, "Club", 200, 9, 2, "Club") },
        { new ItemWeapon(2, "Staff", 410, 20, 6, "Staff") },
    };
}
