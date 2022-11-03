using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    ObjectPool<GameObject> _pool;

    float spawnTimer;
    int[] lanes = { 0, 1, 2, 3, 4 };

    public void BuildTiles(Map e)
    {
        for (int i = 0; i < 1; i++)
        {
            var tile = Instantiate(e.map);
            var player = Instantiate(e.player);
            player.gameObject.SetActive(false);
            tile.gameObject.SetActive(false);
        }
    }

}
