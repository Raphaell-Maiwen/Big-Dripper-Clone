using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerBigDripper : NetworkManager
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private List<GameObject> _availableAnimals;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private HoneyManager _honeyManager;
    private int _index;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        int animalIndex = Random.Range(0, spawnPrefabs.Count);
        GameObject animal = _availableAnimals[animalIndex];
        _availableAnimals.RemoveAt(animalIndex);

        GameObject player = Instantiate(animal, _spawnPoints[_index].position, _spawnPoints[_index].rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        _index++;
        if (_index > 1)
        {
            _timeManager.StartGame();
            _honeyManager.enabled = true;
        }
    }
}
