using UnityEngine;

[System.Serializable]
public class Level
{
    public int levelNumber;
    public int crateCount;
    public float timeAllowed; // Time allowed to complete the level in seconds

    public Level(int levelNumber, int crateCount, float timeAllowed)
    {
        this.levelNumber = levelNumber;
        this.crateCount = crateCount;
        this.timeAllowed = timeAllowed;
    }
}
