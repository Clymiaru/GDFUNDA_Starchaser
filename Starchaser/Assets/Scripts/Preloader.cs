using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    [Tooltip("Path where the Level Data in the Resource Folder is located.")]
    [SerializeField] private string LevelResourceLocation = "Level";

    private void Start()
    {
        Preload();
        LoadManager.Instance.LoadScene(SceneNames.PRE_LEVEL_SCENE);
    }

    private void Preload()
    {
        LevelManager.Instance.PreLoadLevels(LevelResourceLocation);
    }
}
