using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneChoiser : MonoBehaviour
{
    [SerializeField] private List<PlaneColor> _planeColor;
    [SerializeField] private List<Plane> _planeBase;
    [SerializeField] private Image _currentPlane;
    private List<Plane> _unlockedPlanes = new List<Plane>();
    private List<string> _colors = new List<string>() {"Red", "Green", "Yellow", "Blue", "Purple"};
    private string _currentColor;
    private int _choisenPlaneIndex;
    private string _choisenPlaneKey = "choisenPlane";
    private string _choisenColor = "choisenColor";
    private void Start()
    {
        InitializePlane();
        InitializeColor();
    }

    private void InitializePlane()
    {
        _unlockedPlanes.Add(_planeBase[PlayerPrefs.GetInt(_choisenPlaneKey)]);
        int totalUnlockedPlanes = PlayerPrefs.GetInt("prestigeKey");
        _choisenPlaneIndex = 0;
        for(int i = 0; i < totalUnlockedPlanes + 1; i++)
        {
            if (_unlockedPlanes[0] != _planeBase[i])
            {
                _unlockedPlanes.Add(_planeBase[i]);
            }
        }
        _currentColor = PlayerPrefs.GetString(_choisenColor);
        _currentPlane.sprite = _unlockedPlanes[_choisenPlaneIndex].GetColorablePlane(_currentColor);
    }

    public void ChoiseNextPlane()
    {
        if(_choisenPlaneIndex + 1 < _unlockedPlanes.Count)
        {
            _choisenPlaneIndex += 1;
        }
        else
        {
            _choisenPlaneIndex = 0;
        }
        _currentPlane.sprite = _unlockedPlanes[_choisenPlaneIndex].GetColorablePlane(_currentColor);

        PlayerPrefs.SetInt(_choisenPlaneKey, _planeBase.IndexOf(_unlockedPlanes[_choisenPlaneIndex]));
    }
    public void ChoisePrevPlane()
    {
        if (_choisenPlaneIndex - 1 >= 0)
        {
            _choisenPlaneIndex -= 1;
        }
        else
        {
            _choisenPlaneIndex = _unlockedPlanes.Count - 1;
        }
        _currentPlane.sprite = _unlockedPlanes[_choisenPlaneIndex].GetColorablePlane(_currentColor);

        PlayerPrefs.SetInt(_choisenPlaneKey, _planeBase.IndexOf(_unlockedPlanes[_choisenPlaneIndex]));
    }
    private void InitializeColor()
    {
        for(int i = 0; i < _colors.Count; i++)
        {
            if (PlayerPrefs.GetInt(_colors[i]) == 1) 
            {
                _planeColor[i].ColorButton.interactable = true;
            }
        }
        _planeColor[_colors.IndexOf(_currentColor)].ChoisenColorIcon.SetActive(true);
    }
    public void ChoiceColor(string color)
    {
        _planeColor[_colors.IndexOf(_currentColor)].ChoisenColorIcon.SetActive(false);
        _currentColor = color;
        _currentPlane.sprite = _unlockedPlanes[_choisenPlaneIndex].GetColorablePlane(_currentColor);
        _planeColor[_colors.IndexOf(_currentColor)].ChoisenColorIcon.SetActive(true);
        PlayerPrefs.SetString(_choisenColor, _currentColor);
    }
}
