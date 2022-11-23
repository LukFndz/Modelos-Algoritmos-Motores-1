using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System.Linq;

[System.Serializable]
public struct SpawnerParams
{
    public Entity[] entity;
    public LaneParams[] laneParams;
    public int enemyAmount;
    public float timeToSpawn;
    public SpawnerType spawnerType;
}

[System.Serializable]
public struct LaneParams
{
    public Transform spawnPoint;
    public MovementManager.TypeAdvance movementType;
}

[System.Serializable]
public enum SpawnerType
{
    Enemies,
    PowerUp,
    Coin
}


public class EntitySpawner : MonoBehaviour
{
    ObjectPool<Entity> _pool;
    Factory<Entity> _factory;
    public Entity[] entity;
    [SerializeField] private LaneParams[] _laneParams;
    [SerializeField] private int _enemyAmount;
    [SerializeField] private float _timeToSpawn;
    private float _currentTimeToSpawn;
    [SerializeField] private SpawnerType _spawnerType;

    float spawnTimer;
    int [] lanes = { 0, 1, 2, 3, 4 };

    public SpawnerType SpawnerType { get => _spawnerType; set => _spawnerType = value; }
    public float CurrentTimeToSpawn { get => _currentTimeToSpawn; set => _currentTimeToSpawn = value; }
    public float TimeToSpawn { get => _timeToSpawn; set => _timeToSpawn = value; }

    public void BuildEntitySpawner(SpawnerParams e)
    {
        this.entity = e.entity;
        _laneParams = e.laneParams;
        _enemyAmount = e.enemyAmount;
        _factory = new Factory<Entity>(e.entity);
        _pool = new ObjectPool<Entity>(_factory.Get, Entity.TurnOn, Entity.TurnOff, _enemyAmount);
        _timeToSpawn = e.timeToSpawn;
        _currentTimeToSpawn = e.timeToSpawn;
        _spawnerType = e.spawnerType;
    }

    public void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > _currentTimeToSpawn)
        {
            spawnTimer = 0;
            var e = _pool.GetObject();
            e.Create(_pool);

            int random = GetRandomWithoutLastLane();
            e.transform.position = _laneParams[random].spawnPoint.position;
            var advance = MovementManager.Instance.GetMovement(_laneParams[random].movementType, e.gameObject, e.GetComponent<Rigidbody>());

            e.EntityMovement.SetStrategy(advance); // SETEA LA ESTRATEGIA A USAR (RECTA/SINUOSA)
        }
    }
    

    private int GetRandomWithoutLastLane() //DEVUELVE UN RANDOM DISTINTO AL ULTIMO CARRIL
    {
        var list = lanes.Where(x => x != SpawnManager.Instance.LastLane).ToList();
        int result = list[Random.Range(0, list.Count)];
        SpawnManager.Instance.LastLane = result;
        return result;
    }
}

