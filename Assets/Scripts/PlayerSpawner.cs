using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _playerScoreLabels;
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        var label = _playerScoreLabels[playerInput.playerIndex];
        label.gameObject.SetActive(true);
        label.text = "P" + playerInput.playerIndex + ": " + 0;

        //Cleaner: make a dictionary in a UI Manager
        playerInput.GetComponent<Player>().Init(label, playerInput.playerIndex + 1);
    }
}
