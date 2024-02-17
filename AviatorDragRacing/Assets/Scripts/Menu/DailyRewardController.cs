using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DailyRewardController : MonoBehaviour
{
    [SerializeField] private BalanceController _balanceController;

    private int _rewardValue = 100;
    private string _lastBonusTimeKey = "LastBonusTime";
    private DateTime lastBonusTime;
    private TimeSpan bonusCooldown = TimeSpan.FromHours(24);

    private void Start()
    {
        string lastBonusTimeString = PlayerPrefs.GetString(_lastBonusTimeKey, string.Empty);

        if (!string.IsNullOrEmpty(lastBonusTimeString))
        {
            lastBonusTime = DateTime.Parse(lastBonusTimeString);
        }
        else
        {
            lastBonusTime = DateTime.MinValue;
        }
        UpdateRewardState();
    }

    private void UpdateRewardState()
    {
        bool isCooldownOver = DateTime.Now - lastBonusTime >= bonusCooldown;

        if(!isCooldownOver)
        {
            gameObject.SetActive(false);
        }
    }

    public void GetReward()
    {
        _balanceController.SetBalance(_balanceController.GetBalance() + _rewardValue);

        lastBonusTime = DateTime.Now;

        PlayerPrefs.SetString(_lastBonusTimeKey, lastBonusTime.ToString());
        UpdateRewardState();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString(_lastBonusTimeKey, lastBonusTime.ToString());
    }
}
