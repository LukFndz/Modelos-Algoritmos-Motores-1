using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnlyCoins : MonoBehaviour, IPowerUp
{
    public void Disable()
    {
        var spawnCoins = SpawnManager.Instance.SpawnersEntity.Where(x => x.SpawnerType == SpawnerType.Coin).FirstOrDefault();
        SpawnManager.Instance.EnableSpawners();
        spawnCoins.CurrentTimeToSpawn = spawnCoins.TimeToSpawn;
    }
}
