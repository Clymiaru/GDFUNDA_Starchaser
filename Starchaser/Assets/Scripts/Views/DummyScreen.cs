using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScreen : View
{
    private void Start()
    {
        if (GameManager.Instance.CurrentState == GameState.MainMenu)
        {
            this.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.MAIN_MENU, true);
        }

        if (GameManager.Instance.CurrentState == GameState.ChooseLevel)
        {
            this.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
        }
    }
}
