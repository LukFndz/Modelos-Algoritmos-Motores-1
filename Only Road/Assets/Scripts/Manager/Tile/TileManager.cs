using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Maps{
    Beach
}

public class TileManager : Singleton<TileManager>
{
    [SerializeField] private Maps _actualMap;

    [SerializeField] private float _tilesVelocity;
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private Tile[] _tiles;

    private void Start()
    {
        EventManager.Subscribe(EventManager.NameEvent.ApplyMultipliers, ChangeTilesVelocity);
    }

    public float GetTilesVelocity()
    {
        return _tilesVelocity;
    }

    public void ChangeTilesVelocity(params object[] parameters)
    {
        _tilesVelocity += (float)parameters[0];
        foreach(Tile t in _tiles)
        {
            t.ChangeVelocity(_tilesVelocity);
        }
    }

    public Maps GetActualMap()
    {
        return _actualMap;
    }

    public void TransportTile(GameObject tile)
    {
        tile.transform.position = _startSpawn.position;
    }
}
