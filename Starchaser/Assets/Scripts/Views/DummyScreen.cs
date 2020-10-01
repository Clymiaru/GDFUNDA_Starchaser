using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScreen : View
{
    private void Start()
    {
        Debug.Log(GameManager.Instance.CurrentState);
        if (GameManager.Instance.CurrentState == GameState.MainMenu)
        {
            this.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.MAIN_MENU, true);
            EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_ENTER_START);
        }

        if (GameManager.Instance.CurrentState == GameState.ChooseLevel)
        {
            this.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
            EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_ENTER_START);
        }

    }
}
