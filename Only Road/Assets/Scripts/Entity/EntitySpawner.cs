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
    public int timeToSpawn;
}

[System.Serializable]
public struct LaneParams
{
    public Transform spawnPoint;
    public MovementManager.TypeAdvance movementType;
}


public class EntitySpawner : MonoBehaviour
{
    ObjectPool<Entity> _pool;
    Factory<Entity> _factory;
    public Entity[] entity;
    [SerializeField] private LaneParams[] _laneParams;
    [SerializeField] private int _enemyAmount;
    [SerializeField] private int _timeToSpawn;

    float spawnTimer;
    int [] lanes = { 0, 1, 2, 3, 4 };

    public void BuildEntitySpawner(SpawnerParams e)
    {
        this.entity = e.entity;
        _laneParams = e.laneParams;
        _enemyAmount = e.enemyAmount;
        _factory = new Factory<Entity>(e.entity);
        _pool = new ObjectPool<Entity>(_factory.Get, Entity.TurnOn, Entity.TurnOff, _enemyAmount);
        _timeToSpawn = e.timeToSpawn;
    }

    public void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > _timeToSpawn)
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

