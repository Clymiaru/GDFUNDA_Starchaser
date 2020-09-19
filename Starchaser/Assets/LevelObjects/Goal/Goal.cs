using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.isLevelFinished)
        {
            var currentView = ViewHandler.Instance.GetActiveView();
            currentView.Hide();
            ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.RESULTS);
            GameManager.LevelIsFinished();
        }

    }
}
