using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : View
{
    public void OnStartGameClick()
    {
        Debug.Log("Start Game was Clicked!");
    }

    public void OnSettingButtonClick()
    {
        Debug.Log("Settings was Clicked!");
    }

    public void OnEndButtonClick()
    {
        Debug.Log("End was Clicked!");
    }
}
