using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionScreen : View
{
    [SerializeField] private Text currentLevelLabel;
    [SerializeField] private Image currentLevelImage;

    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    [SerializeField] private Text ARankRequirement;
    [SerializeField] private Text SRankRequirement;


    private int currentLevelID = 0;
    private int minLevels = 0;
    private int maxLevels = 3;


    private void Start()
    {
        LevelManager.Instance.PreLoadLevelInformation("Levels");
        currentLevelID = PlayerPrefs.GetInt("LevelID", 0);
        maxLevels = LevelManager.Instance.LevelCount;
        UpdateCurrentLevel();
    }

    public void OnPrevLevelButtonClicked()
    {
        currentLevelID--;
        currentLevelID = Mathf.Max(currentLevelID, minLevels);
        UpdateCurrentLevel();
    }

    public void OnNextLevelButtonClicked()
    {
        currentLevelID++;
        currentLevelID = Mathf.Min(currentLevelID, maxLevels-1);
        UpdateCurrentLevel();
    }

    public void UpdateCurrentLevel()
    {
        PlayerPrefs.SetInt("LevelID", currentLevelID);
        
        if (currentLevelID <= minLevels)
        {
            HideButton(prevButton);
        }
        else
        {
            ShowButton(prevButton);
        }

        if (currentLevelID == (maxLevels - 1))
        {
            HideButton(nextButton);
        }
        else
        {
            ShowButton(nextButton);
        }

        var level = LevelManager.Instance.GetLevel(currentLevelID);
        currentLevelLabel.text = level.Data.Name;
        currentLevelImage.sprite = level.Data.Image;

        //TODO: Format in time (00:00:00)
        var aData = level.Data.ARankRequirement;
        ARankRequirement.text = $"A: {aData.minutes}:00:00";

        //TODO: Format in time (00:00:00)
        var sData = level.Data.SRankRequirement;
        SRankRequirement.text = $"S: {sData.minutes}:00:00";
    }

    private void HideButton(Button toHide)
    {
        toHide.interactable = false;
    }

    private void ShowButton(Button toHide)
    {
        toHide.interactable = true;
    }
}
