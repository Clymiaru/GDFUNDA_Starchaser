using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
}

[CreateAssetMenu(fileName = "New Level", menuName = "Starchaser/Level")]
public class LevelData : ScriptableObject
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
    [SerializeField] private int achievedScore;

    public string Name
    {
        get
        {
            return levelName;
        }
        set
        {
            levelName = value;
        }
    }

    public Sprite Image
    {
        get
        {
            return levelImage;
        }
    }

    public TimeData ARankRequirement
    {
        get
        {
            return timeRequiredForRankA;
        }
    }

    public TimeData SRankRequirement
    {
        get
        {
            return timeRequiredForRankS;
        }
    }

    public bool IsUnlocked
    {
        get
        {
            return isUnlocked;
        }
    }

    public Rank AchievedRank
    {
        get
        {
            return AchievedRank;
        }
    }

    public TimeData AchievedTime
    {
        get
        {
            return achievedTime;
        }
    }

    public int AchievedScore
    {
        get
        {
            return achievedScore;
        }
    }

}