using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private OpponentGenerator _opponentGenerator;
    [SerializeField] private List<Plane> _planeBase;
    [SerializeField] private GamePlane _player;
    [SerializeField] private GamePlane _opponent;

    [SerializeField] private Image _trafficLight;
    [SerializeField] private List<Sprite> _trafficLightSprites;
    private void Start()
    {
        _player.InitializePlane(PlayerPrefs.GetInt("StartingSpeed"), PlayerPrefs.GetInt("AccelerationSpeed"), PlayerPrefs.GetInt("Stability"), PlayerPrefs.GetInt("PilotLevel"), _planeBase[PlayerPrefs.GetInt("choisenPlane")].GetColorablePlane(PlayerPrefs.GetString("choisenColor")));
        _opponent.InitializePlane(_opponentGenerator.GetStats()[0].GetStat(), _opponentGenerator.GetStats()[1].GetStat(), _opponentGenerator.GetStats()[2].GetStat(), _opponentGenerator.GetStats()[3].GetStat(), _opponentGenerator.GetOpponentSprite());

        StartCoroutine(TrafficLightStart());
    }

    private IEnumerator TrafficLightStart()
    {
        _trafficLight.sprite = _trafficLightSprites[0];
        yield return new WaitForSeconds(1.5f);
        _trafficLight.sprite = _trafficLightSprites[1];
        yield return new WaitForSeconds(1.5f);
        _trafficLight.sprite = _trafficLightSprites[2];
        yield return new WaitForSeconds(0.5f);
        _trafficLight.gameObject.SetActive(false);

        _player.SetFly();
        _opponent.SetFly();
    }

    
}
