using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
public class VolumeSFXController : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;
    [SerializeField] Toggle _toggle;
    private bool _disableToggleEvent;
    [SerializeField] GameObject Warning;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
        _toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }

    private void HandleToggleValueChanged(bool enableSound)
    {
        if (_disableToggleEvent)
            return;

        if (enableSound)
        {
            _slider.value = _slider.maxValue;
            
        }
            
           
        else
        {
            _slider.value = _slider.minValue;
            
        }
            
            
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
        
    }

    private void HandleSliderValueChanged(float value)
    {
        if (value == _slider.minValue && Warning != null)
        {
            Warning.SetActive(true);
        }
        else if (Warning != null)
        {
            Warning.SetActive(false);
        }
        
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

    // Update is called once per frame
    
}
