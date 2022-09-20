using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvyAdvance : IAdvance
{
    private float _velocity;
    private GameObject _enemy;
    private Rigidbody _rb;
    private float freq;
    private float mag;
    private float speed;


    public CurvyAdvance(float velocity, Rigidbody rb, GameObject enemy, float freq, float mag, float speed)
    {
        _velocity = velocity;
        _rb = rb;
        _enemy = enemy;
        this.freq = freq;
        this.mag = mag;
        this.speed = speed;
    }

    public void Advance()
    {
        _enemy.transform.position += (Vector3.forward * Time.deltaTime * speed) * Mathf.Sin(Time.time * freq) * mag;
        _rb.velocity += _enemy.transform.right * _velocity;
    }
}
