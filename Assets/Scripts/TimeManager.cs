using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeLabel;
    [SerializeField] private float _matchTime;
    private float _countDown;

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
        Debug.Log("Game Over");
        Time.timeScale = 0;
        enabled = false;
    }
}
