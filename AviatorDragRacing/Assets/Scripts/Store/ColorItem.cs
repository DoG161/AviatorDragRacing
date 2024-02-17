using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorItem : MonoBehaviour
{
    [SerializeField] private BalanceController _balance;
    [SerializeField] private string _colorKey;
    [SerializeField] private GameObject _isBuyedObj;
    [SerializeField] private GameObject _priceField;
    private bool _isBuyed;
    private void Start()
    {
        InitializeColors();
    }
    public void InitializeColors()
    {
        if(PlayerPrefs.GetInt(_colorKey) == 0)
        {
            _priceField.SetActive(true);
            _isBuyed = false;
        }
        else
        {
            _isBuyedObj.SetActive(true);
            _isBuyed = true;
        }
    }
    public void BuyColor()
    {
        if(!_isBuyed && _balance.GetBalance() >= 300)
        {
            _isBuyed = true;
            _balance.SetBalance(_balance.GetBalance() - 300);
            _priceField.SetActive(false);
            _isBuyedObj.SetActive(true);
            PlayerPrefs.SetInt(_colorKey, 1);
        }
    }
}
