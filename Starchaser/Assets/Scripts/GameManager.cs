using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{ 
    MainMenu,
    ChooseLevel,
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

    private PlayerStatus playerStatus;
    TimeData currentAchievedTime;

    public static GameManager Instance
    {
        get
        {
            if (sharedInstance == null)
            {
                sharedInstance = new GameManager();

                EventBroadcaster.Instance.AddObserver(EventNames.Starchaser.ON_GAME_STATE_SWITCH, GameManager.Instance.SwitchGameState);
                //EventBroadcaster.Instance.AddObserver(EventNames.Starchaser.ON_GAME_STATE_SWITCH, );
            }

            return sharedInstance;
        }
    }

    public void SwitchGameState(Parameters param)
    {
        currentState = (GameState)param.GetIntExtra("GameState", 0);
        Debug.Log(currentState);
    }

    public bool IsPaused { get => isPaused; }
    public GameState CurrentState { get => currentState; }

    public void SaveAchievedTime(TimeData timeData) => currentAchievedTime = timeData;
    public TimeData AchievedTime { get => currentAchievedTime; }
    public PlayerStatus Status { get => playerStatus; }
    public void PlayerWon() =>  playerStatus = PlayerStatus.Won;
    public void PlayerLost() => playerStatus = PlayerStatus.Lost;

}
