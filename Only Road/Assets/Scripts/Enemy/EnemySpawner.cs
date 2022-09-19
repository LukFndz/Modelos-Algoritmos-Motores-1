using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    ObjectPool<Enemy> _pool;
    [SerializeField] private List<Transform> spawnPoint;
    void Start()
    {
        _pool = new ObjectPool<Enemy>(Factory, Enemy.TurnOn, Enemy.TurnOff, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var e = _pool.GetObject();
            e.Create(_pool);
            e.transform.position = spawnPoint[Random.Range(0, 6)].position;
        }
    }

    public Enemy Factory()
    {
        return Instantiate(enemy);
    }
}
