using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSelector : MonoBehaviour
{
    [SerializeField] private GameObject _distanceScreen;
    [SerializeField] private GameObject _opponentScreen;
    private int _distance;
    public void SelectDistance(int distanceIndex)
    {
        _distance = distanceIndex;
        _distanceScreen.SetActive(false);
        _opponentScreen.SetActive(true);
    }
}
