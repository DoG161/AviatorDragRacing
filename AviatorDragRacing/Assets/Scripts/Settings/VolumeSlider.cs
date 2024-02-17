using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private VolumeEssence _volumeEssence;
    [SerializeField] private Slider _volumeSlider;
    public void ChangeVolume()
    {
        _volumeEssence.SetVolume(_volumeSlider.value);
    }
    public void Initialize()
    {
        _volumeSlider.value = _volumeEssence.GetVolume();
    }
}
