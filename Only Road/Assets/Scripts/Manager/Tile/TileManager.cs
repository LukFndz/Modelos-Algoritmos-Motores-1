using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileManager : Singleton<TileManager>
{
    [SerializeField] private float _tilesVelocity;
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private List<Tile> _tiles;
    [SerializeField] private float _multiplier;
   
    public List<Tile> Tiles { get => _tiles; set => _tiles = value; }
    public float Multiplier { get => _multiplier; set => _multiplier = value; }

    public float GetTilesVelocity()
    {
        return _tilesVelocity;
    }

    public void TransportTile(GameObject tile)
    {
        tile.transform.position = new Vector3(_startSpawn.position.x, tile.transform.position.y, tile.transform.position.z);
    }
}
