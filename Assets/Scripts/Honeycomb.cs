using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honeycomb : MonoBehaviour
{
    private bool _readyToDrop = true;
    public bool ReadyToDrop => _readyToDrop;

    public void OnDropSpawned() 
    {
        _readyToDrop = false;
    }

    public void OnDropReachedPuddle() 
    {
        _readyToDrop = true;
    }
}
