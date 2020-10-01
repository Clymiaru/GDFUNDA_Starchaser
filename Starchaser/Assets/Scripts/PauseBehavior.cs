using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    private bool isPaused = false;
    private bool isQuit = false;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_ENTER_COMPLETE, PauseGame);
        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_EXIT_COMPLETE, ResumeGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_ENTER_START);
            }
            else
            {
                EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_EXIT_START);
            }
        }
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.UITransition.ON_ENTER_COMPLETE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.UITransition.ON_EXIT_COMPLETE);
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        if (isQuit)
        {
            GameManager.Instance.SetState(GameState.ChooseLevel);
            LoadManager.Instance.LoadScene(SceneNames.PRE_LEVEL_SCENE);
        }
    }


    public void OnResumeButtonClick()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_EXIT_START);
    }

    public void OnGiveUpButtonClick()
    {
        isQuit = true;
        EventBroadcaster.Instance.PostEvent(EventNames.UITransition.ON_EXIT_START);
    }
}
