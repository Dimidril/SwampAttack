using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        Slider.value = 1;
        _player.HelthChanged += OnValueChanged;
        
    }

    private void OnDisable()
    {
        _player.HelthChanged -= OnValueChanged;
    }

}