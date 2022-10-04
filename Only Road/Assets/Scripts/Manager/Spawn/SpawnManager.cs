using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private int _lastLane;

    [SerializeField] private List<SpawnerParams> _spawners;


    private EntitySpawner[] _spawnersEntity;

    public int LastLane { get => _lastLane; set => _lastLane = value; }

    private void Start()
    {
        _spawnersEntity = FindObjectsOfType<EntitySpawner>();
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawnersEntity[i].BuildEntitySpawner(_spawners[i]);
            _spawnersEntity[i].enabled = false;
        }

        if(!GameManager.Instance.GameState)
            gameObject.SetActive(false);

        EventManager.Subscribe(EventManager.NameEvent.Gameover, DisableSpawners);
    }

    public void EnableSpawners()
    {
        foreach (EntitySpawner e in _spawnersEntity)
            e.enabled = true;
    }

    public void DisableSpawners(params object[] parameters)
    {
        foreach (EntitySpawner e in _spawnersEntity)
            e.enabled = false;
    }



}
