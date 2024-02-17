using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeEssence : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSouce;
    private float _currentVolume;
    private string _audioKey = "OKg91ae";

    private void Start()
    {
        Initialize();
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(_audioKey, _currentVolume);
    }
    public void Initialize()
    {
        if(!PlayerPrefs.HasKey(_audioKey))
        {
            PlayerPrefs.SetFloat(_audioKey, 0);
        }
        _currentVolume = PlayerPrefs.GetFloat(_audioKey);
        _audioSouce.volume = _currentVolume;
    }
    public float GetVolume()
    {
        return _currentVolume;
    }

    public void SetVolume(float newVolumeValue)
    {
        _currentVolume = newVolumeValue;
        _audioSouce.volume = _currentVolume;
    }
}
