using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvyAdvance : IAdvance
{
    private float _velocity;
    private GameObject _entity;
    private Rigidbody _rb;
    private float freq;
    private float mag;
    private float speed;


    public CurvyAdvance(float velocity, Rigidbody rb, GameObject entity, float freq, float mag, float speed)
    {
        _velocity = velocity;
        _rb = rb;
        _entity = entity;
        this.freq = freq;
        this.mag = mag;
        this.speed = speed;
    }

    public void Advance() //AVANZA
    {
        _entity.transform.position += (Vector3.forward * Time.deltaTime * speed) * Mathf.Sin(Time.time * freq) * mag;
        _entity.transform.position += _entity.transform.right * _velocity * Time.deltaTime;
    }

    public void ChangeVel(float newVel) //CAMBIAR LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE
    {
        _velocity = newVel;
    }

    public float GetVelocity() //DEVUELVE LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE
    {
        return _velocity;
    }
}
