using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    ObjectPool<Enemy> _pool;
    Factory<Enemy> _factory;
    [SerializeField] private List<Transform> spawnPoint;

    private float spawnTimer;

    void Start()
    {
        _factory = new Factory<Enemy>(enemy);    
        _pool = new ObjectPool<Enemy>(_factory.Get, Enemy.TurnOn, Enemy.TurnOff, 8);
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
            e.transform.position = spawnPoint[EnemySelector.SetEnemy(e)].position; //SPAWNEO UN ENEMIGO EN UN CARRIL ALEATORIO
        }
    }
}
