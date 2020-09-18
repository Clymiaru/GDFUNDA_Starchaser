using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : View
{
    public void OnStartGameClick()
    {
        Debug.Log("Start Game was Clicked!");
        ViewHandler.Instance.OnViewHidden(this);
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }

    public void OnEndButtonClick()
    {
        Debug.Log("End was Clicked!");
        Application.Quit();
    }
}
