using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatItem : MonoBehaviour
{
    [SerializeField] private BalanceController _balance;
    [SerializeField] private string _statKey;
    [SerializeField] private TextMeshProUGUI _priceField;
    [SerializeField] private List<Image> _statsIcons;
    [SerializeField] private Sprite _activeStatSprite;
    private int _statCount;
    private int _nextStatPrice;

    private void Start()
    {
        InitializeStat();
    }
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

        if (_statCount != 5)
        {
            _nextStatPrice = _statCount * 100;
            _priceField.text = _nextStatPrice.ToString();
        }
        else
        {
            _priceField.gameObject.SetActive(false);
        }
    }
    public void BuyStat()
    {
        if(_statCount != _statsIcons.Count && _balance.GetBalance() >= _nextStatPrice)
        {
            _balance.SetBalance(_balance.GetBalance() - _nextStatPrice);
            _statCount++;
            _nextStatPrice = _statCount * 100;
            if (_statCount != 5)
            {
                _priceField.text = _nextStatPrice.ToString();
            }
            else
            {
                _priceField.gameObject.SetActive(false);
            }

            for (int i = 0; i < _statCount; i++)
            {
                _statsIcons[i].sprite = _activeStatSprite;
            }

            PlayerPrefs.SetInt(_statKey, _statCount);
        }
    }
}
