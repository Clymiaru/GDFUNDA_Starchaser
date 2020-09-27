using System;
using UnityEngine;

public enum Rank
{
    None,
    RankD,
    RankC,
    RankB,
    RankA,
    RankS
}

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
    [SerializeField] private TimeData timeRequiredForRankA;
    [SerializeField] private TimeData timeRequiredForRankS;
    [SerializeField] private string levelSceneName;

    // Level Data to Track for Saving
    [Header("")]
    [SerializeField] private bool isUnlocked;
    [SerializeField] private Rank achievedRank;
    [SerializeField] private TimeData achievedTime;

    public string Name
    {
        get => levelName;
        set => levelName = value;
    }

    public string LevelScene { get => levelSceneName; }
    public Sprite Image { get => levelImage; }
    public TimeData ARankRequirement { get => timeRequiredForRankA; }
    public TimeData SRankRequirement { get => timeRequiredForRankS; }
    public bool IsUnlocked { get => isUnlocked; }
    public Rank AchievedRank { get => achievedRank; }
    public TimeData AchievedTime { get => achievedTime; }
}