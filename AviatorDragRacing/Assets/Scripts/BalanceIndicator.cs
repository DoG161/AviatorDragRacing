using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _balanceField;
    private void Awake()
    {
        BalanceController.OnBalanceChanged += RefreshBalanceField;
    }
    private void OnDestroy()
    {
        BalanceController.OnBalanceChanged -= RefreshBalanceField;
    }
    public void RefreshBalanceField(int balance)
    {
        _balanceField.text = balance.ToString();
    }
}
