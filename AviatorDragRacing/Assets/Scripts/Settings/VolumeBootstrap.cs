using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBootstrap : MonoBehaviour
{
    [SerializeField] private VolumeEssence _volumeEssence;
    [SerializeField] private VolumeSlider _volumeSlider;
    private void Start()
    {
        _volumeEssence.Initialize();
        _volumeSlider.Initialize();
    }
}
