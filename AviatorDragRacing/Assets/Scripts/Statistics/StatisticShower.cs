using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statText;
    [SerializeField] private string _statTitle;
    [SerializeField] private string _statKey;
    private void Start()
    {
        LoadStat();
    }

    private void LoadStat()
    {
        if(!PlayerPrefs.HasKey(_statKey))
        {
            PlayerPrefs.SetInt(_statKey, 0);
        }

        _statText.text = _statTitle + ": " + PlayerPrefs.GetInt(_statKey);
    }
}
