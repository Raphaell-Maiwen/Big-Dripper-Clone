using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeLabel;
    [SerializeField] private TextMeshProUGUI _winnerLabel;
    [SerializeField] private float _matchTime;
    private float _countDown;

    public List<Player> _players = new List<Player>();

    private void Awake()
    {
        _countDown = _matchTime;
        UpdateLabel();
    }

    private void Update()
    {
        _countDown -= Time.deltaTime;
        UpdateLabel();

        if ((int)_countDown <= 0) 
        {
            EndOfGame();
        }
    }

    void UpdateLabel() 
    {
        _timeLabel.text = ((int)_countDown).ToString();
    }

    void EndOfGame() 
    {
        Time.timeScale = 0;
        enabled = false;

        int maxScore = 0;
        int bestPlayer = -1;

        foreach (var player in _players)
        {
            if (player.GetScore() > maxScore) 
            { 
                maxScore = player.GetScore();
                bestPlayer = player.GetIndex();
            }
        }

        _winnerLabel.gameObject.SetActive(true);

        if (bestPlayer == -1)
        {
            _winnerLabel.text = "No one wins!";
        }
        else
        {
            _winnerLabel.text = "Player " + bestPlayer + " wins!";
        }
    }
}
