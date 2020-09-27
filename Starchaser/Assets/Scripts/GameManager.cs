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


    private Level currentLevelData;
    private PlayerStatus playerStatus;
    TimeData currentAchievedTime;

    public static GameManager Instance
    {
        get
        {
            if (sharedInstance == null)
            {
                sharedInstance = new GameManager();

                //EventBroadcaster.Instance.AddObserver(EventNames.Starchaser.ON_GAME_STATE_SWITCH, );

            }

            return sharedInstance;
        }
    }

    private void SwitchGameState(Parameters param)
    {
        currentState = (GameState)param.GetIntExtra("GameState", 0);
    }


    public void UpdateCurrentLevelData(int currentID)
    {
        currentLevelData = LevelManager.Instance.GetLevel(currentID);
    }

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
    

    public GameState CurrentState { get => currentState; }

    public void SaveAchievedTime(TimeData timeData)
    {
        currentAchievedTime = timeData;
    }
    public TimeData AchievedTime { get => currentAchievedTime; }
    public Level CurrentLevelData { get => currentLevelData; }
    public PlayerStatus Status { get => playerStatus; }

    public void PlayerWon()
    {
        playerStatus = PlayerStatus.Won;
    }

    public void PlayerLost()
    {
        playerStatus = PlayerStatus.Lost;
        Debug.Log("Status changed");
    }
    public string Rank { get => "A"; }

}
