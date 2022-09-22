using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
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

    ObjectPool<Entity> _referenceBack;


    //COMPOSITION
    private EntityMovement _entityMovement;

    public EntityMovement EntityMovement { get => _entityMovement; set => _entityMovement = value; }

    private void Awake()
    {
        _entityMovement = new EntityMovement(velocity, rb, gameObject,_frequency,_magnitude,_turnSpeed);
        _entityMovement.ManualAwake();
    }

    private void Update()
    {
        _entityMovement.ManualUpdate();
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

    public void Create(ObjectPool<Entity> op)
    {
        _referenceBack = op;
    }

    public static void TurnOn(Entity e)
    {
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(Entity e)
    {
        e.ResetBullet();
        e.gameObject.SetActive(false);
    }
}
