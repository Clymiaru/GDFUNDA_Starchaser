using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHUD : View
{
    [SerializeField] TMP_Text timerInfo;

    private float timer = 0;
    private int minutes = 0;
    private int seconds = 0;

    private void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.PlayLevel)
        {
            timer += Time.deltaTime;
            minutes = (int)timer / 60;
            seconds = (int)timer - 60 * minutes;
            GameManager.Instance.SaveAchievedTime(new TimeData(timer));
        }

        timerInfo.text = $"{minutes:D2}:{seconds:D2}";
    }
}
