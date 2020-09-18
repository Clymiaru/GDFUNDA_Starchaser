using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHUD : View
{
    public void OnContinueButtonClick()
    {
        Debug.Log("<color=red>PauseHUD</color> Continue was Clicked!");
        ViewHandler.Instance.HideCurrentView();
    }

    public void OnRetryButtonClick()
    {
        Debug.Log("<color=red>ResultsHUD</color> Retry was Clicked!");
        //ViewHandler.Instance.OnViewHidden(this);
        //ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }

    public void OnGiveUpButtonClick()
    {
        Debug.Log("<color=red>ResultsHUD</color> Give Up was Clicked!");
        ViewHandler.Instance.OnViewHidden(this);
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }
}
