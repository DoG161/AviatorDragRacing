using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentStat : MonoBehaviour
{
    [SerializeField] private List<Image> _statImages;
    [SerializeField] private Sprite _active, _notActive;
    private int _statCount = 0;
    public void SetStat(int count)
    {
        for(int i = 0; i < count; i++)
        {
            _statImages[i].sprite = _active;
        }
        for(int i = count; i < _statImages.Count; i++)
        {
            _statImages[i].sprite = _notActive;
        }
        _statCount = count;
    }

    public int GetStat()
    {
        return _statCount;
    }
}
