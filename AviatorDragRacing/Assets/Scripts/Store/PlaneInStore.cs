using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneInStore : MonoBehaviour
{
    [SerializeField] private List<Plane> _planeBase;
    [SerializeField] private Image _currentPlaneImage;
    private string _choisenPlaneKey = "choisenPlane";
    private string _choisenColor = "choisenColor";
    private Plane _currentPlane;
    private void Start()
    {
        InitializePlane();
    }

    private void InitializePlane()
    {
        _currentPlane = _planeBase[PlayerPrefs.GetInt(_choisenPlaneKey)];
        _currentPlaneImage.sprite = _currentPlane.GetColorablePlane(PlayerPrefs.GetString(_choisenColor));
    }
}
