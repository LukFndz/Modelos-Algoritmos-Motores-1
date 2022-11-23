using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnlyCoinObject : CollectionableItem, IPowerUpObject
{
    public override void GetItem()
    {
        Touch();
        base.GetItem();
    }

    public void Touch()
    {
        PowerUpManager.Instance.ActivatePowerUp();
        PowerUpManager.Instance.ActualPowerUp = new OnlyCoins();
        var spawnCoins = SpawnManager.Instance.SpawnersEntity.Where(x => x.SpawnerType == SpawnerType.Coin).FirstOrDefault();
        SpawnManager.Instance.DisableSpawners();
        spawnCoins.enabled = true;
        spawnCoins.CurrentTimeToSpawn = 0.5f;
    }
}
