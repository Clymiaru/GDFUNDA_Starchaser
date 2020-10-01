using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SoundManager.Instance.Volume;
        EventBroadcaster.Instance.AddObserver(EventNames.Starchaser.ON_VOLUME_UPDATE, ChangeVolume);
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Starchaser.ON_VOLUME_UPDATE);
    }

    private void ChangeVolume(Parameters param)
    {
        SoundManager.Instance.Volume = param.GetFloatExtra("Volume", 0.0f);
        audioSource.volume = SoundManager.Instance.Volume;
    }

    public void PlayClip()
    {
        audioSource.Play();
    }
}
