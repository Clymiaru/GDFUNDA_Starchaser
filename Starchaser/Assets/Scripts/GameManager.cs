using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{ 
    MainMenu,
    ChooseLevel,
    LevelIntro,
    PlayLevel,
    ViewResults
}

public enum PlayerStatus
{ 
    Won, 
    Lost
}


public class GameManager
{
    private static GameManager sharedInstance = null;

    private GameState currentState = GameState.MainMenu;
    private bool isPaused = false;
    private LevelData currentLevelData;
    private PlayerStatus playerStatus;
    TimeData currentAchievedTime;

    public static GameManager Instance
    {
        get
        {
            if (sharedInstance == null)
            {
                sharedInstance = new GameManager();

                LevelManager.Instance.PreLoadLevelInformation("Levels");
            }

            return sharedInstance;
        }
    }

    public void UpdateCurrentLevelData(int currentID)
    {
        currentLevelData = LevelManager.Instance.GetLevel(currentID).Data;
    }

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
    

    public GameState CurrentState
    { 
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
        }
    }

    public void SaveAchievedTime(TimeData timeData)
    {
        currentAchievedTime = timeData;
    }

    public TimeData AchievedTime
    {
        get
        {
            return currentAchievedTime;
        }
    }

    public LevelData CurrentLevelData
    {
        get
        {
            return currentLevelData;
        }
    }

    public PlayerStatus Status
    {
        get
        {
            return playerStatus;
        }
    }

    public void PlayerWon()
    {
        playerStatus = PlayerStatus.Won;
    }

    public void PlayerLost()
    {
        playerStatus = PlayerStatus.Lost;
        Debug.Log("Status changed");
    }

    public string Rank
    {
        get
        {
            return "A";
        }
    }

}
