using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    [SerializeField] private List<Image> _statsIcons;
    [SerializeField] private Sprite _activeStatSprite;
    [SerializeField] private string _statKey;
    private int _statCount;
    public void InitializeStat()
    {
        if(!PlayerPrefs.HasKey(_statKey))
        {
            PlayerPrefs.SetInt(_statKey, 1);
        }
        _statCount = PlayerPrefs.GetInt(_statKey);

        for(int i = 0; i < _statCount; i++)
        {
            _statsIcons[i].sprite = _activeStatSprite;
        }
    }
}
