using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeLabel;
    [SerializeField] private TextMeshProUGUI _winnerLabel;
    [SerializeField] private float _matchTime;

    [SyncVar(hook = nameof(OnTimeChanged))]
    private float _countDown;

    [SyncVar(hook = nameof(OnGameStarted))]
    private bool _gameStarted;

    public List<Player> _players = new List<Player>();

    private void Awake()
    {
        _countDown = _matchTime;
        UpdateLabel();
    }

    private void OnGameStarted(bool oldValue, bool newValue)
    {
        if(newValue)
        {
            _timeLabel.gameObject.SetActive(true);
        }
    }

    [Server]
    public void StartGame()
    {
        _gameStarted = true;
        enabled = true;
    }

    private void Update()
    {
        if (isServer) 
        {
            _countDown -= Time.deltaTime;

            if ((int)_countDown <= 0)
            {
                EndOfGame();
            }
        }
    }

    void OnTimeChanged(float oldValue, float newValue)
    {
        UpdateLabel();
    }

    void UpdateLabel() 
    {
        _timeLabel.text = ((int)_countDown).ToString();
    }

    [ClientRpc]
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

    private void OnServerInitialized()
    {
        _winnerLabel.gameObject.SetActive(false);
    }
}
