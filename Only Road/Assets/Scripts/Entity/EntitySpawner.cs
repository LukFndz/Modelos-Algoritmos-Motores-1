using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public Entity entity;
    ObjectPool<Entity> _pool;
    Factory<Entity> _factory;
    [SerializeField] private List<Transform> spawnPoint;

    private float spawnTimer;

    void Start()
    {
        _factory = new Factory<Entity>(entity);    
        _pool = new ObjectPool<Entity>(_factory.Get, Entity.TurnOn, Entity.TurnOff, 8);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > 2)
        {
            spawnTimer = 0;
            var e = _pool.GetObject();
            e.Create(_pool);
            e.transform.position = spawnPoint[EntitySelector.SetEntity(e)].position; //SPAWNEO UN ENEMIGO EN UN CARRIL ALEATORIO
        }
    }
}
