using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TimeData
{
    public int milliseconds;
    public int seconds;
    public int minutes;
}

[CreateAssetMenu(menuName = "Starchaser/Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private string levelName;
    [SerializeField] private Sprite levelImage;
    [SerializeField] private TimeData timeRequiredForRankA;
    [SerializeField] private TimeData timeRequiredForRankS;

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

}