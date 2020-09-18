using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class LevelSelectionScreen : View
{
    [SerializeField] private Image currentLevelImage;

    [SerializeField] private Button prevButton;
    [SerializeField] private Text currentLevelLabel;
    [SerializeField] private Button nextButton;

    [SerializeField] private Text scoreInfo;
    [SerializeField] private Text timeInfo;
    [SerializeField] private Image rankImage;

    [SerializeField] private Text rankARequirementInfo;
    [SerializeField] private Text rankSRequirementInfo;

    private int currentLevelID = 0;
    private int minLevels = 0;
    private int maxLevels = 3;

    private void Start()
    {
        LevelManager.Instance.PreLoadLevelInformation("Levels");
        currentLevelID = PlayerPrefs.GetInt("LevelID", 0);
        maxLevels = LevelManager.Instance.LevelCount - 1;
        UpdateCurrentLevel();
    }

    public void OnPrevLevelButtonClicked()
    {
        currentLevelID--;
        UpdateCurrentLevel();
    }

    public void OnNextLevelButtonClicked()
    {
        currentLevelID++;
        UpdateCurrentLevel();
    }

    public void UpdateCurrentLevel()
    {
        currentLevelID = Mathf.Clamp(currentLevelID, minLevels, maxLevels);
        PlayerPrefs.SetInt("Starchaser-LevelSelection-SelectedLevelID", currentLevelID);
        
        if (currentLevelID <= minLevels)
        {
            HideButton(prevButton);
        }
        else
        {
            ShowButton(prevButton);
        }

        if (currentLevelID >= maxLevels)
        {
            HideButton(nextButton);
        }
        else
        {
            ShowButton(nextButton);
        }

        var level = LevelManager.Instance.GetLevel(currentLevelID);
        ShowLevelData(level);
    }

    private void ShowLevelData(Level level)
    {
        var levelData = level.Data;

        currentLevelLabel.text = levelData.Name;
        currentLevelImage.sprite = levelData.Image;

        scoreInfo.text = $"{levelData.AchievedScore:D12}";

        var achievedTime = levelData.AchievedTime;
        timeInfo.text = achievedTime.ToString();
        //rankImage.sprite;

        var aData = levelData.ARankRequirement;
        rankARequirementInfo.text = aData.ToString();

        var sData = levelData.SRankRequirement;
        rankSRequirementInfo.text = sData.ToString();
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
