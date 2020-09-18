using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreen : View
{
    public void OnEndButtonClick()
    {
        Debug.Log("<color=red>ResultsHUD</color> End was Clicked!");
        ViewHandler.Instance.OnViewHidden(this);
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }

    public void ShowScore()
    {

    }
    public void ShowTime()
    {

    }

    public void ShowRank()
    {

    }
}
