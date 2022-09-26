using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EntityParams
{
    public Transform spawnPoint;
    public MovementManager.TypeAdvance movementType;
}

public class EntitySpawner : MonoBehaviour
{
    public Entity entity;
    ObjectPool<Entity> _pool;
    Factory<Entity> _factory;
    [SerializeField] private float _spawnTime;
    [SerializeField] private EntityParams[] _entityParams;


    float spawnTimer;

    void Start()
    {
        _factory = new Factory<Entity>(entity);    
        _pool = new ObjectPool<Entity>(_factory.Get, Entity.TurnOn, Entity.TurnOff, 8);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > _spawnTime) // CADA X SEGUNDOS SPAWNEA UNA ENTIDAD
        {
            spawnTimer = 0;
            var e = _pool.GetObject();
            e.Create(_pool);

            int random = Random.Range(0, _entityParams.Length);
            e.transform.position = _entityParams[random].spawnPoint.position;
            var advance = MovementManager.Instance.GetMovement(_entityParams[random].movementType, e.gameObject, e.GetComponent<Rigidbody>());

            e.EntityMovement.SetStrategy(advance);
            e.EntityMovement.ChangeVelocity(MovementManager.Instance.GetEnemiesVelocity()); // CADA VEZ QUE SE PRENDE, SE CAMBIA LA VELOCIDAD A LA ACTUAL
        }
    }
}

