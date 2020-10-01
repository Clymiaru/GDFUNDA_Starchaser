using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = SoundManager.Instance.Volume;
        EventBroadcaster.Instance.AddObserver(EventNames.UITransition.ON_EXIT_COMPLETE, DisableSlider);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.UITransition.ON_EXIT_COMPLETE, DisableSlider);
    }

    public void DisableSlider() => slider.interactable = false;

    public void ChangeVolume(float value)
    {
        Parameters param = new Parameters();
        param.PutExtra("Volume", value);

        EventBroadcaster.Instance.PostEvent(EventNames.Starchaser.ON_VOLUME_UPDATE, param);
    }
}
