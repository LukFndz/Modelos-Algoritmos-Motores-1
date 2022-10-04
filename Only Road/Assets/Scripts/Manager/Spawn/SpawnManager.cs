using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private int _lastLane;

    [SerializeField] private List<SpawnerParams> _spawners;


    List<EntitySpawner> _spawnersEntity = new List<EntitySpawner>();

    public int LastLane { get => _lastLane; set => _lastLane = value; }

    private void Start()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawnersEntity.Add(gameObject.AddComponent<EntitySpawner>());
            _spawnersEntity[i].BuildEntitySpawner(_spawners[i]);
            _spawnersEntity[i].enabled = false;
        }

        if(!GameManager.Instance.GameState)
            gameObject.SetActive(false);

        EventManager.Instance.Subscribe(EventManager.NameEvent.Gameover, DisableSpawners);
        EventManager.Instance.Subscribe(EventManager.NameEvent.StartGame, EnableSpawners);
    }

    public void EnableSpawners(params object[] parameters)
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
