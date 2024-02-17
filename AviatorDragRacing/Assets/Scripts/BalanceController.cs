using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceController : MonoBehaviour
{
    public static Action<int> OnBalanceChanged;
    private string _balanceKey = "KgM14A4S";
    private int _currentBalanceValue;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        Initialize();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(_balanceKey, _currentBalanceValue);
    }

    public void Initialize()
    {
        if(!PlayerPrefs.HasKey(_balanceKey))
        {
            PlayerPrefs.SetInt(_balanceKey, 2000);
        }
        _currentBalanceValue = PlayerPrefs.GetInt(_balanceKey);
        OnBalanceChanged?.Invoke(_currentBalanceValue);
    }
    public int GetBalance()
    {
        return _currentBalanceValue;
    }
    public void SetBalance(int value)
    {
        _currentBalanceValue = value;
        OnBalanceChanged?.Invoke(_currentBalanceValue);
    }
}
