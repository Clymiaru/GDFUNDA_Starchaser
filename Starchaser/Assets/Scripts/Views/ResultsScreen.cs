using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsScreen : View
{
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text timeInfo;
    [SerializeField] private TMP_Text statusInfo;

    private void Update()
    {
        TimeData current = GameManager.Instance.AchievedTime;
        timeInfo.text = current.ToString();

        levelName.text = GameManager.Instance.CurrentLevelData.Name;

        statusInfo.text = (GameManager.Instance.Status == PlayerStatus.Won) ? "Stage All Clear!!" : "You Died :)";

    }
    public void OnEndButtonClick()
    {
        Debug.Log("<color=red>ResultsHUD</color> End was Clicked!");
        this.Hide();
        LoadManager.Instance.LoadScene("Pre-Level");
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
        GameManager.Instance.CurrentState = GameState.ChooseLevel;
    }
}
