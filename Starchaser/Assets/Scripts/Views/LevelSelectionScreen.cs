using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class LevelSelectionScreen : View
{
    [SerializeField] private Image currentLevelImage;
    [SerializeField] private Button prevButton;
    [SerializeField] private TMP_Text currentLevelLabel;
    [SerializeField] private Button nextButton;

    private int currentLevelID = 0;

    private readonly int minLevelID = 0;
    private int maxLevelID = 3;

    private void Start()
    {
        currentLevelID = PlayerPrefs.GetInt("LevelID", minLevelID);
        maxLevelID = LevelManager.Instance.LevelCount - 1;
        UpdateCurrentLevel();
    }

    public void OnReturnToMainMenuButtonClick()
    {
        Debug.Log("<color=red>LevelSelectionScreen</color> Return to Main Menu was Clicked!");

        this.Hide();
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.MAIN_MENU, true);
        PlayerPrefs.SetInt("LevelID", currentLevelID);
        //GameManager.Instance.CurrentState = GameState.MainMenu;
    }

    public void OnExploreButtonClick()
    {
        Debug.Log("<color=red>LevelSelectionScreen</color> Explore was Clicked!");
        PlayerPrefs.SetInt("LevelID", currentLevelID);

        this.Hide();
        LevelManager.Instance.LoadLevel(currentLevelID);
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
        currentLevelID = Mathf.Clamp(currentLevelID, minLevelID, maxLevelID);
        PlayerPrefs.SetInt("Starchaser-LevelSelection-SelectedLevelID", currentLevelID);
        
        if (currentLevelID <= minLevelID)
        {
            HideButton(prevButton);
        }
        else
        {
            ShowButton(prevButton);
        }

        if (currentLevelID >= maxLevelID)
        {
            HideButton(nextButton);
        }
        else
        {
            ShowButton(nextButton);
        }

        var level = LevelManager.Instance.GetLevel(currentLevelID);
        UpdateLevelInfo(level);
    }

    private void UpdateLevelInfo(Level level)
    {
        currentLevelLabel.text = level.Name;
        UpdateLevelImage(level);
    }

    private void UpdateLevelImage(Level level)
    {
        if (level.IsUnlocked)
        {
            currentLevelImage.sprite = level.Image;
        }
        // Else Replace with a locked sprite
    }

    private void HideButton(Button toHide) => toHide.interactable = false;
    private void ShowButton(Button toHide) => toHide.interactable = true;

    
}
