using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : View
{
    public void OnStartGameClick()
    {
        Debug.Log("<color=red>MainMenuScreen</color> Start Game was Clicked!");
        this.Hide();
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }

    public void OnEndButtonClick()
    {
        Debug.Log("<color=red>MainMenuScreen</color> End was Clicked!");
        Application.Quit();
    }
}
