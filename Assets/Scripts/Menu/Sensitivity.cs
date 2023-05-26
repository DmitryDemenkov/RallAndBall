using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public static float Value { get { return _value; } }

    private static float _value;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = SettingsUtil.GetSensitivity();
        _value = _slider.value;
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    public void Save()
    {
        SettingsUtil.SetSensitivity(_slider.value);
    }

    private void OnValueChanged(float value)
    {
        _value = value;
    }
}
