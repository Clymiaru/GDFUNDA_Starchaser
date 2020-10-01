using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : View
{

    private void Start()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_ENTER_START);
    }
    public void OnStartGameClick()
    {
        Debug.Log("<color=red>MainMenuScreen</color> Start Game was Clicked!");
        GoToLevelSelection();
    }

    public void OnEndButtonClick()
    {
        Debug.Log("<color=red>MainMenuScreen</color> End was Clicked!");
        Application.Quit();
    }

    private void GoToLevelSelection()
    {
        var param = new Parameters();
        param.PutExtra("GameState", (int)GameState.ChooseLevel);
        EventBroadcaster.Instance.PostEvent(EventNames.Starchaser.ON_GAME_STATE_SWITCH, param);

        this.Hide();
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }
    
}
