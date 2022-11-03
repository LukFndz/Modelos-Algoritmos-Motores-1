using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileManager : Singleton<TileManager>
{
    [SerializeField] private float _tilesVelocity;
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private List<Tile> _tiles;

   
    public List<Tile> Tiles { get => _tiles; set => _tiles = value; }

    private void Start()
    {
        EventManager.Instance.Subscribe(EventManager.NameEvent.ApplyMultipliers, ChangeTilesVelocity);
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

    public void TransportTile(GameObject tile)
    {
        tile.transform.position = _startSpawn.position;
    }
}
