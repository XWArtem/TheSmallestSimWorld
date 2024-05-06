public abstract class ItemBase
{
    public int ID;
    public string Name;
    public int Cost;
    public string SpriteName;

    public ItemBase(int ID, string name, int cost, string spriteName)
    {
        this.ID = ID;
        Name = name;
        Cost = cost;
        SpriteName = spriteName;
    }
}