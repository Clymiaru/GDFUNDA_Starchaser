using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public void ChangeVolume(float value)
    {
        Parameters param = new Parameters();
        param.PutExtra("Volume", value);

        EventBroadcaster.Instance.PostEvent(EventNames.Starchaser.ON_VOLUME_UPDATE, param);

        Debug.Log(value);
    }
}
