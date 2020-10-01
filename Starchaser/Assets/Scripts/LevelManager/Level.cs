using System;
using UnityEngine;

[Serializable]
public struct TimeData
{
    public int milliseconds;
    public int seconds;
    public int minutes;

    public override string ToString()
    {
        return $"{minutes:D2}:{seconds:D2}\"{milliseconds:D3}";
    }

    public TimeData(float time)
    {
        minutes = (int)time / 60;
        seconds = (int)time - 60 * minutes;
        milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
    }
}

[CreateAssetMenu(fileName = "New Level", menuName = "Starchaser/Level")]
public class Level : ScriptableObject
{
    // Level Information
    [Header("Level Information")]
    [SerializeField] private string levelName;
    [SerializeField] private Sprite levelImage;
    [SerializeField] private string levelSceneName;
    [SerializeField] private bool isUnlocked;

    public string Name
    {
        get => levelName;
    }

    public string LevelScene { get => levelSceneName; }
    public Sprite Image { get => levelImage; }
    public bool IsUnlocked { get => isUnlocked; }
}