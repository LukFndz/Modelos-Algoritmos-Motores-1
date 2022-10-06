using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("OBJECT POOL")]
    [SerializeField] private int _maxTime;
    private float _counter;

    ObjectPool<Entity> _referenceBack;

    //COMPOSITION
    private EntityMovement _entityMovement;

    public EntityMovement EntityMovement { get => _entityMovement; set => _entityMovement = value; }

    private void OnEnable()
    {
        
    }

    private void Awake()
    {
        _entityMovement = new EntityMovement();
    }

    private void Start()
    {
        _entityMovement.ManualStart();
    }

    private void Update()
    {
        _entityMovement.ManualUpdate();

        _counter += Time.deltaTime; 
        
        if(_counter >= _maxTime) // CADA X TIEMPO LA ENTIDAD DESAPARECE
        {
            _referenceBack.ReturnObject(this);
        }
    }

    public void ResetCounter()
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
        e.ResetCounter();
        e.gameObject.SetActive(false);
    }
}
