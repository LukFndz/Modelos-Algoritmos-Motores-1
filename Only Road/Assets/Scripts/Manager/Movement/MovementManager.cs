using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : Singleton<MovementManager>
{
    [Header("STRAIGHT PARAMS")]
    [Range(20,45)]
    [SerializeField]private float _velocity;
                    private Rigidbody _rb;
                    private GameObject _enemy;

    [Header("CURVY PARAMS")]
    [SerializeField]private float _freq;
    [SerializeField]private float _mag;
    [SerializeField]private float _speed;

    public enum TypeAdvance
    {
        Straight,
        Curvy,
        Both
    }

    public IAdvance GetMovement(TypeAdvance type, GameObject e, Rigidbody rb) //DEVUELVE LA ESTRATEGIA
    {
        switch(type)
        {
            case TypeAdvance.Straight:
                return new NormalAdvance(_velocity, rb, e);
            case TypeAdvance.Curvy:
                return new CurvyAdvance(_velocity, rb, e, _freq, _mag, _speed);
            case TypeAdvance.Both:
                if(Random.Range(0,2) == 1)
                    return new CurvyAdvance(_velocity, rb, e, _freq, _mag, _speed);
                else
                    return new NormalAdvance(_velocity, rb, e);
            default:
                return new NormalAdvance(_velocity, rb, e);
        }
    }

    public void ChangeVelocity(float newVel)
    {
        _velocity += newVel;
    }

    public float GetEnemiesVelocity()
    {
        return _velocity;
    }
}
