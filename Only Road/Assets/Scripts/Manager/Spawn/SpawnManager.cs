using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private List<int> _lastLanes;
    [SerializeField] private float _entitiesSpawnBetweenTime;
    [SerializeField] private float _collectionableSpawnBetweenTime;
    [SerializeField] private List<EntitySpawner> _spawners;

    float collectionableCounter;
    float spawnTimer;

    private void Start()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawners[i] = new EntitySpawner(_spawners[i]);
        }

        if(!GameManager.Instance.GameState)
            gameObject.SetActive(false);

    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        collectionableCounter += Time.deltaTime;

        if (spawnTimer > _entitiesSpawnBetweenTime)
        {
            switch(collectionableCounter)
            {
                case float n when n < _collectionableSpawnBetweenTime:
                    _spawners[0].SpawnEntity();
                    break;
                case float n when n > _collectionableSpawnBetweenTime:
                    _spawners[Random.Range(1,3)].SpawnEntity();
                    ResetCounter();
                    collectionableCounter = 0;
                    break;
                default:
                    _spawners[2].SpawnEntity();
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
