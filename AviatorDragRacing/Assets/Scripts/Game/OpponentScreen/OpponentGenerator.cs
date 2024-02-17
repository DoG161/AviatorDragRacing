using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class OpponentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _game2Screen;
    [SerializeField] private BalanceController _balance;
    [SerializeField] private List<OpponentStat> _opponentStats;
    [SerializeField] private Image _opponentIcon;
    [SerializeField] private List<Plane> _planeBase;
    private int _playerStatsCount;
    private void Start()
    {
        _planeBase.RemoveAt(PlayerPrefs.GetInt("choisenPlane"));
        _playerStatsCount = PlayerPrefs.GetInt("StartingSpeed") + PlayerPrefs.GetInt("AccelerationSpeed") + PlayerPrefs.GetInt("Stability") + PlayerPrefs.GetInt("PilotLevel");
        GenerateStats(0);
    }

    public void GenerateStats(int cost)
    {
        if (_balance.GetBalance() >= cost)
        {
            _balance.SetBalance(_balance.GetBalance() - cost);
            GenerateOpponentIcon();
            int bufPlayerStats = _playerStatsCount;
            foreach (OpponentStat opponentStat in _opponentStats)
            {
                opponentStat.SetStat(1);
            }
            bufPlayerStats -= 4;

            while (bufPlayerStats != 0)
            {
                bufPlayerStats--;
                List<OpponentStat> _notFullStats = new List<OpponentStat>();
                foreach (OpponentStat opponentStat in _opponentStats)
                {
                    if (opponentStat.GetStat() != 5)
                    {
                        _notFullStats.Add(opponentStat);
                    }
                }
                int whatStat = Random.Range(0, _notFullStats.Count);
                _notFullStats[whatStat].SetStat(_notFullStats[whatStat].GetStat() + 1);
            }
        }
    }

    private void GenerateOpponentIcon()
    {
        _opponentIcon.sprite = _planeBase[Random.Range(0, _planeBase.Count)].GetRandomColorSprite();
    }

    public void StartGame(int cost)
    {
        if (_balance.GetBalance() >= cost)
        {
            _balance.SetBalance(_balance.GetBalance() - cost);
            gameObject.SetActive(false);
            _gameScreen.SetActive(true);
            _game2Screen.SetActive(true);
        }
    }
    public List<OpponentStat> GetStats()
    {
        return _opponentStats;
    }
    public Sprite GetOpponentSprite()
    {
        return _opponentIcon.sprite;
    }
    
}
