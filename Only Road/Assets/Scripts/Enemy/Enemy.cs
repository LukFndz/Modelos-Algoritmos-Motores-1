using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("MOVEMENT")]
    [SerializeField] private float velocity;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Rigidbody rb;

    [Header("CURVY MOVEMENT")]
    [SerializeField]private float _frequency;
    [SerializeField]private float _magnitude;
    [SerializeField]private float _turnSpeed;

    [Header("OBJECT POOL")]
    [SerializeField] private int _maxTime;
    private float _counter;

    ObjectPool<Enemy> _referenceBack;


    //COMPOSITION
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = new EnemyMovement(velocity, rb, gameObject,_frequency,_magnitude,_turnSpeed);
        _enemyMovement.ManualAwake();
    }

    private void Update()
    {
        _enemyMovement.ManualUpdate();
        _counter += Time.deltaTime;
        
        if(_counter >= _maxTime)
        {
            _referenceBack.ReturnObject(this);
        }
    }

    public void ResetBullet()
    {
        _counter = 0;
    }

    public void Create(ObjectPool<Enemy> op)
    {
        _referenceBack = op;
    }

    public static void TurnOn(Enemy e)
    {
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(Enemy e)
    {
        e.ResetBullet();
        e.gameObject.SetActive(false);
    }
}
