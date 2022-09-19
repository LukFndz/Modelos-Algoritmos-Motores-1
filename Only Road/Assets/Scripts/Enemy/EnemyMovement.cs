using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement
{
    private float _velocity;
    private Rigidbody _rb;
    private GameObject _enemy;

    public EnemyMovement(float velocity, Rigidbody rb, GameObject enemy)
    {
        this._velocity = velocity;
        this._rb = rb;
        this._enemy = enemy;
    }

    public void ManualUpdate()
    {
        _rb.velocity += _enemy.transform.right * _velocity;
    }
}
