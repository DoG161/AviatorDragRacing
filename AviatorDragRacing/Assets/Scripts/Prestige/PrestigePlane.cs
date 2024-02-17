using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigePlane : MonoBehaviour
{
    [SerializeField] private int _winsToUnlock;
    [SerializeField] private Image _planeIcon;
    [SerializeField] private Image _greenLine;

    public bool InitializePlane(int winCount)
    {
        _greenLine.fillAmount = (float)winCount / (float)_winsToUnlock;
        if(winCount >= _winsToUnlock)
        {
            _planeIcon.color = new Color(1, 1, 1, 1);
            return true;
        }
        return false;
    }


}
