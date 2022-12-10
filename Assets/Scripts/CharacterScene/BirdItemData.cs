
[System.Serializable]
public class BirdItemData
{
    public string Name;
    public bool Enabled;

    public BirdItemData() { }
    public BirdItemData(string name, bool enabled)
    {
        Name = name;
        Enabled = enabled;
    }

    public BirdItemData(BirdItem birdItem)
    {
        Name = birdItem.Name;
        Enabled = birdItem.Enabled;
    }
    
}