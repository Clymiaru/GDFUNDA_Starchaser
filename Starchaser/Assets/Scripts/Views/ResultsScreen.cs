using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreen : View
{
    public void OnEndButtonClick()
    {
        Debug.Log("<color=red>ResultsHUD</color> End was Clicked!");
        this.Hide();
        LoadManager.Instance.LoadScene("Pre-Level");
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
