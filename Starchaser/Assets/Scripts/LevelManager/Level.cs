using System.Collections;
using System.Collections.Generic;
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

public class Level
{
    public LevelData Data { get; }
    //private bool isUnlocked;
    //private Rank achievedRank;
    //private TimeData achievedTime; // Store the most quickest time recorded
    //private int achievedScore;

    public Level(LevelData levelData)
    {
        Data = levelData;
    }
}