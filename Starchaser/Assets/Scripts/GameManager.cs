using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool isLevelFinished { get; private set; } = false;

    public static void LevelIsFinished()
    {
        isLevelFinished = true;
        
        // Save current time data and level id
    }

    public static void SetLevelData()
    {

    }
}
