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

    private void Start()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawners[i] = new EntitySpawner(_spawners[i]);
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
                    _spawners[0].SpawnEntity();
                    break;
                case float n when n > _coinsSpawnBetweenTime:
                    _spawners[1].SpawnEntity();
                    ResetCounter();
                    coinCounter = 0;
                    break;
                default:
                    _spawners[0].SpawnEntity();
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
