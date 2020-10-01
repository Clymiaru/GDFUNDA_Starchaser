using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Starchaser.ON_PLAYER_HEALTH_UPDATE, UpdateHealthBar);
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Starchaser.ON_PLAYER_HEALTH_UPDATE);
    }

    void UpdateHealthBar(Parameters param)
    {
        slider.value = param.GetFloatExtra("PlayerHealth", 0.0f) / slider.maxValue;
    }
}
