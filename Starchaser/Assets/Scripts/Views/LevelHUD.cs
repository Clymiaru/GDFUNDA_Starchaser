using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHUD : View
{
    [SerializeField] TMP_Text timerInfo;
    private TimeData timeData;

    private float timer = 0;
    private int minutes = 0;
    private int seconds = 0;
    private void Update()
    {
        if (!GameManager.isLevelFinished)
        {
            timer += Time.deltaTime;
            minutes = (int)timer / 60;
            seconds = (int)timer - 60 * minutes;
        }

        timerInfo.text = $"{minutes:D2}:{seconds:D2}";
    }
}
