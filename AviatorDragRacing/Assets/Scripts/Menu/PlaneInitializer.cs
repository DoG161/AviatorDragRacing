using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneInitializer : MonoBehaviour
{
    [SerializeField] private List<Plane> _planeBase;
    [SerializeField] private Image _currentPlane;
    private List<string> _colors = new List<string>() { "Red", "Green", "Yellow", "Blue", "Purple" };
    private string _choisenPlaneKey = "choisenPlane";
    private string _choisenColor = "choisenColor";
    private void Start()
    {
        InitializePlane();
    }

    private void InitializePlane()
    {
        if (!PlayerPrefs.HasKey(_choisenColor))
        {
            PlayerPrefs.SetString(_choisenColor, _colors[0]);
            PlayerPrefs.SetInt(_colors[0], 1);
            for(int i = 1; i < _colors.Count; i++)
            {
                PlayerPrefs.SetInt(_colors[i], 0);
            }
        }
        _currentPlane.sprite = _planeBase[PlayerPrefs.GetInt(_choisenPlaneKey)].GetColorablePlane(PlayerPrefs.GetString(_choisenColor));
    }
}
