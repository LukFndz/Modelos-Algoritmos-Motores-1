using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private List<int> _lastLanes;
    [SerializeField] private float _entitiesSpawnBetweenTime;
    [SerializeField] private float _coinsSpawnBetweenTime;
    [SerializeField] private List<EntitySpawner> _spawners;

    float coinCounter;
    float spawnTimer;
    private List<EntitySpawner> _spawnersEntities = new List<EntitySpawner>();

    private void Start()
    {
        foreach (EntitySpawner e in _spawners)
        {
            EntitySpawner entitySpawner = new EntitySpawner(e);
            _spawnersEntities.Add(entitySpawner);
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        coinCounter += Time.deltaTime;
        if(spawnTimer > _entitiesSpawnBetweenTime)
        {
            switch(coinCounter)
            {
                case float n when n < _coinsSpawnBetweenTime:
                    _spawnersEntities[0].SpawnEntity();
                    break;
                case float n when n > _coinsSpawnBetweenTime:
                    _spawnersEntities[1].SpawnEntity();
                    ResetCounter();
                    coinCounter = 0;
                    break;
                default:
                    _spawnersEntities[0].SpawnEntity();
                    break;
            }
            ResetCounter();
        }
    }
    public void ResetCounter()
    {
        spawnTimer = 0;
    }
}
