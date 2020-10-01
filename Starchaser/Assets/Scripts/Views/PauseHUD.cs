using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHUD : View
{
    public void OnContinueButtonClick()
    {
        Debug.Log("<color=red>PauseHUD</color> Continue was Clicked!");
        ViewHandler.Instance.HideCurrentView();

        // Continue Event
    }

    public void OnRetryButtonClick()
    {
        Debug.Log("<color=red>PauseHUD</color> Retry was Clicked!");
        //ViewHandler.Instance.OnViewHidden(this);
        //ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);

        // Retry Event
    }

    public void OnGiveUpButtonClick()
    {
        Debug.Log("<color=red>PauseHUD</color> Give Up was Clicked!");
        ViewHandler.Instance.OnViewHidden(this);
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);

        // Give Up Event
    }
}
