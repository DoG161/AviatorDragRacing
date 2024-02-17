using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _prestigeField;
    [SerializeField] private List<PrestigePlane> _presigePlanes;
    [SerializeField] private Button _prestigeButton;
    private int _currentPrestige;
    private string _prestigeKey = "prestigeKey";
    private void Start()
    {
        InitializePlanes();
        InitializePrestigeText();
        InitializePrestigeButton();
    }

    private void InitializePrestigeText()
    {
        _prestigeField.text = "PRESTIGE LEVEL: " + PlayerPrefs.GetInt(_prestigeKey);
    }

    private void InitializePlanes()
    {
        _currentPrestige = 0;
        for(int i = 0; i < _presigePlanes.Count; i++)
        {
            if (_presigePlanes[i].InitializePlane(PlayerPrefs.GetInt("victory")))
            {
                _currentPrestige = i + 1;
            }
            else
            {
                break;
            }
        }
    }
    private void InitializePrestigeButton()
    {
        if(!PlayerPrefs.HasKey(_prestigeKey)) 
        {
            PlayerPrefs.SetInt(_prestigeKey, 0);
        }
        if(_currentPrestige > PlayerPrefs.GetInt(_prestigeKey))
        {
            _prestigeButton.interactable = true;
        }
    }
    public void TakeAward()
    {
        _prestigeButton.interactable = false;
        PlayerPrefs.SetInt(_prestigeKey, _currentPrestige);
        PlayerPrefs.DeleteKey("StartingSpeed");
        PlayerPrefs.DeleteKey("AccelerationSpeed");
        PlayerPrefs.DeleteKey("Stability");
        PlayerPrefs.DeleteKey("PilotLevel");
        InitializePlanes();
        InitializePrestigeText();
    }
}
