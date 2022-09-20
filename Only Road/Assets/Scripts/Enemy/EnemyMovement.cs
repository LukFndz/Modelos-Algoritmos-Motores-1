using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement
{
    private float _velocity;
    private Rigidbody _rb;
    private GameObject _enemy;
    private float _freq;
    private float _mag;
    private float _speed;


    IAdvance[] _currents = new IAdvance[2];
    IAdvance _currentStrategy;

    public EnemyMovement(float velocity, Rigidbody rb, GameObject enemy, float freq, float mag, float speed)
    {
        this._velocity = velocity;
        this._rb = rb;
        this._enemy = enemy;
        this._freq = freq;
        this._mag = mag;
        this._speed = speed;
    }

    public void ManualAwake()
    {
        _currents[0] = new NormalAdvance(_velocity, _rb,_enemy);
        _currents[1] = new CurvyAdvance(_velocity, _rb, _enemy,_freq,_mag,_speed);

        _currentStrategy = _currents[0];
    }

    public void ManualUpdate()
    {
        _currentStrategy.Advance();
    }
}
