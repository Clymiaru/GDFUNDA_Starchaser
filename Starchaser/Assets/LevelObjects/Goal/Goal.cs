using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.CurrentState == GameState.PlayLevel)
        {
            var currentView = ViewHandler.Instance.GetActiveView();
            currentView.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.RESULTS, true);
            GameManager.Instance.PlayerWon();
            GameManager.Instance.CurrentState = GameState.ViewResults;
        }

    }
}
