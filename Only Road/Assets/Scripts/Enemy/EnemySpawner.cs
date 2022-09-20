using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    ObjectPool<Enemy> _pool;
    Factory<Enemy> _factory;
    [SerializeField] private List<Transform> spawnPoint;

    void Start()
    {
        _factory = new Factory<Enemy>(enemy);    
        _pool = new ObjectPool<Enemy>(_factory.Get, Enemy.TurnOn, Enemy.TurnOff, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var e = _pool.GetObject();
            e.Create(_pool);
            e.transform.position = spawnPoint[Random.Range(0, 5)].position;
        }
    }
}
