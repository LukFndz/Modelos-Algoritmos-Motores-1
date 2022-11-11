using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : Singleton<MovementManager>
{
    [Header("STRAIGHT PARAMS")]
    [Range(20,45)]
    [SerializeField] private float _initialVelocity;
    [SerializeField] private float _multiplier;


    private Rigidbody _rb;
                    private GameObject _enemy;

    [Header("CURVY PARAMS")]
    [SerializeField]private float _freq;
    [SerializeField]private float _mag;
    [SerializeField]private float _speed;

    public float Multiplier { get => _multiplier; set => _multiplier = value; }

    public enum TypeAdvance
    {
        Straight,
        Curvy,
        Both
    }

    private void Start()
    {
        EventManager.Instance.Subscribe(EventManager.NameEvent.ApplyMultipliers, ChangeVelocity);
    }

    public IAdvance GetMovement(TypeAdvance type, GameObject e, Rigidbody rb) //DEVUELVE LA ESTRATEGIA
    {
        switch(type)
        {
            case TypeAdvance.Straight:
                return new NormalAdvance(rb, e);
            case TypeAdvance.Curvy:
                return new CurvyAdvance(rb, e, _freq, _mag, _speed);
            case TypeAdvance.Both:
                if (Random.Range(0, 2) == 1)
                    return new CurvyAdvance(rb, e, _freq, _mag, _speed);
                else
                    return new NormalAdvance(rb, e);
            default:
                return new NormalAdvance(rb, e);
        }
    }

    public void ChangeVelocity(params object[] parameters)
    {
        TileManager.Instance.Multiplier = (float)parameters[0];
        _multiplier += (float)parameters[1];
    }

    public float GetEntityVelocity()
    {
        return _initialVelocity + _multiplier;
    }
}
