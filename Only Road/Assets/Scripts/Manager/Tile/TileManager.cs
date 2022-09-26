using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    [SerializeField] private float _tilesVelocity;
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private Tile[] _tiles;

    public float GetTilesVelocity()
    {
        return _tilesVelocity;
    }

    public void ChangeTilesVelocity(float newVel)
    {
        _tilesVelocity += newVel;
        foreach(Tile t in _tiles)
        {
            t.ChangeVelocity(_tilesVelocity);
        }
    }

    public void TransportTile(GameObject tile)
    {
        tile.transform.position = _startSpawn.position;
    }
}
