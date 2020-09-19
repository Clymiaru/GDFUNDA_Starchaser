using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;

    [SerializeField] private Slider slider;

    void Start()
    {
        player = FindObjectOfType<Player>();
        slider.maxValue = player.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.Health;
    }
}
