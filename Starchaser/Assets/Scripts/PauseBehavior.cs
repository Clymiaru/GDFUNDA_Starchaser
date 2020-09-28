using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseScreen.activeSelf)
                PauseGame();
            else
                ResumeGame();
        }
    }

    private void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitLevel()
    {
        Time.timeScale = 1;
        LoadManager.Instance.LoadScene("Pre-Level");
        ViewHandler.Instance.Show(ViewNames.StarchaserScreenNames.LEVEL_SELECTION, true);
    }
}
