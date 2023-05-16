[System.Serializable]
public class LevelData
{
    public int currentLevel;
    public bool levelisSave;

    public LevelData(int currentLevel)
    {
        this.currentLevel = currentLevel;
    }

    public LevelData(LevelData LevelData)
    {
        this.currentLevel = LevelData.currentLevel;
    }
}
