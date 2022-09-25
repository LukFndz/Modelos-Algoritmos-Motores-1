using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    public float tilesVelocity;
    [SerializeField] private Transform _startSpawn;

    public void TransportTile(GameObject tile)
    {
        tile.transform.position = _startSpawn.position;
    }
}
