using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private string _planeKey;
    [SerializeField] private List<Sprite> _planeColors;

    public Sprite GetColorablePlane(string colorName)
    {
        if (colorName == "Red")
        {
            return _planeColors[0];
        }
        else if (colorName == "Green")
        {
            return _planeColors[1];
        }
        else if (colorName == "Yellow")
        {
            return _planeColors[2];
        }
        else if (colorName == "Blue")
        {
            return _planeColors[3];
        }
        else
        {
            return _planeColors[4];
        }
    }
    public string GetPlaneKey()
    {
        return _planeKey;
    }

    public Sprite GetRandomColorSprite()
    {
        return _planeColors[Random.Range(0, _planeColors.Count)];
    }
}
