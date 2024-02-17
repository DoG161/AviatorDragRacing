using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatLoader : MonoBehaviour
{
    [SerializeField] private List<Stat> _statList;
    [SerializeField] private TextMeshProUGUI _safetyField;
    private void Start()
    {
        for (int i = 0; i < _statList.Count; i++)
        {
            _statList[i].InitializeStat();
            float safetyPercent = Mathf.Round((float)PlayerPrefs.GetInt("Stability") / ((float)(PlayerPrefs.GetInt("StartingSpeed") + (float)PlayerPrefs.GetInt("AccelerationSpeed")) / 2) * 100);
            if(safetyPercent > 100)
            {
                safetyPercent = 100;
            }
            _safetyField.text = "Safety: " + safetyPercent.ToString() + "%";
        }
    }
}
