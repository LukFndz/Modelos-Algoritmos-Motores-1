using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileManager : Singleton<TileManager>
{
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private List<Tile> _tiles;
    [SerializeField] private float _multiplier;
   
    public List<Tile> Tiles { get => _tiles; set => _tiles = value; }
    public float Multiplier { get => _multiplier; set => _multiplier = value; }

    private void Update()
    {
        Debug.Log(_multiplier);
    }

    public float GetTilesVelocity()
    {
        return _multiplier;
    }

    public void TransportTile(GameObject tile)
    {
        tile.transform.position = new Vector3(_startSpawn.position.x, tile.transform.position.y, tile.transform.position.z);
    }
}
