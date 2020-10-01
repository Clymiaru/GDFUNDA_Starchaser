using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.CurrentState == GameState.PlayLevel)
        {
            Physics.gravity = Vector3.down * 9.81f;
            var currentView = ViewHandler.Instance.GetActiveView();
            currentView.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.RESULTS, true);
            GameManager.Instance.PlayerWon();

            Parameters param = new Parameters();
            param.PutExtra("GameState", (int)GameState.ViewResults);
            GameManager.Instance.SwitchGameState(param);
        }

    }
}
