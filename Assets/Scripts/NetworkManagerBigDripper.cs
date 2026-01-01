using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerBigDripper : NetworkManager
{
    //Use spawnPrefabs for the animals
    [SerializeField] private Transform[] _spawnPoints;
    private int _index;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab, _spawnPoints[_index].position, _spawnPoints[_index].rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        _index++;
    }
}
