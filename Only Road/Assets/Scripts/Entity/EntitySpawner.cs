using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

//LUCA FERNANDEZ - TP1

[System.Serializable]
public struct EntityParams
{
    public Transform spawnPoint;
    public MovementManager.TypeAdvance movementType;
}

[System.Serializable]
public class EntitySpawner
{
    public Entity entity;
    ObjectPool<Entity> _pool;
    Factory<Entity> _factory;
    [SerializeField] private EntityParams[] _entityParams;
    [SerializeField] private int _enemyAmount;

    float spawnTimer;

    public EntitySpawner(EntitySpawner e)
    {
        this.entity = e.entity;
        _entityParams = e._entityParams;
        _enemyAmount = e._enemyAmount;
        _factory = new Factory<Entity>(e.entity);
        _pool = new ObjectPool<Entity>(_factory.Get, Entity.TurnOn, Entity.TurnOff, _enemyAmount);

    }

    public void SpawnEntity()
    {
        var e = _pool.GetObject();
        e.Create(_pool);

        int random = Random.Range(0, _entityParams.Length);
        e.transform.position = _entityParams[random].spawnPoint.position;
        var advance = MovementManager.Instance.GetMovement(_entityParams[random].movementType, e.gameObject, e.GetComponent<Rigidbody>());

        e.EntityMovement.SetStrategy(advance);
        e.EntityMovement.ChangeVelocity(MovementManager.Instance.GetEntityVelocity()); // CADA VEZ QUE SE PRENDE, SE CAMBIA LA VELOCIDAD A LA ACTUAL
    }
}

