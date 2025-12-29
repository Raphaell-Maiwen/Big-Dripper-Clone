using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private TextMeshProUGUI[] _playerScoreLabels;
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        var label = _playerScoreLabels[playerInput.playerIndex];
        label.gameObject.SetActive(true);
        label.text = "P" + playerInput.playerIndex + ": " + 0;

        //Cleaner: make a dictionary in a UI Manager
        var player = playerInput.GetComponent<Player>();
        player.Init(label, playerInput.playerIndex + 1);
        _timeManager._players.Add(player);
    }
}
