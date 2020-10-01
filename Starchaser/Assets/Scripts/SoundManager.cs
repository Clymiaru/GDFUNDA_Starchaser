using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    private static SoundManager sharedInstance = null;
    public static SoundManager Instance
    {
        get
        {
            if (sharedInstance == null)
            {
                sharedInstance = new SoundManager();
            }

            return sharedInstance;
        }
    }

    private float volume = 1.0f;
    public float Volume
    {
        get => volume;
        set
        {
            volume = Mathf.Clamp(value, 0.0f, 1.0f);
            PlayerPrefs.SetFloat("Volume", volume);
        }
    }


}
