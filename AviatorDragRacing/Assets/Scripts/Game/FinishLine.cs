using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private BalanceController _balance;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _lose;
    private bool _isFinish;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isFinish)
        {
            if (collision.gameObject.tag == "Player")
            {
                _isFinish = true;
                _win.SetActive(true);
                PlayerPrefs.SetInt("victory", PlayerPrefs.GetInt("victory") + 1);
                _balance.SetBalance(_balance.GetBalance() + 50);
            }
            else
            {
                _isFinish = true;
                _lose.SetActive(true);
                PlayerPrefs.SetInt("defeat", PlayerPrefs.GetInt("defeat") + 1);
            }    
        }
    }
}
