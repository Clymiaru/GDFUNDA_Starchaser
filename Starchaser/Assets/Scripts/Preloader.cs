using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    private void Start()
    {
        Preload();
        LoadManager.Instance.LoadScene("Pre-Level");
    }

    private void Preload()
    {
        LevelManager.Instance.PreLoadLevels("Levels");
    }
}
