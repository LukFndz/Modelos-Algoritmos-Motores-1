using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvyAdvance : IAdvance
{
    private GameObject _entity;
    private Rigidbody _rb;
    private float freq;
    private float mag;
    private float speed;
    private int breakGame = 1;


    public CurvyAdvance(Rigidbody rb, GameObject entity, float freq, float mag, float speed)
    {
        _rb = rb;
        _entity = entity;
        this.freq = freq;
        this.mag = mag;
        this.speed = speed;
    }

    public void Advance() //AVANZA
    {
        _entity.transform.position += ((Vector3.forward * Time.deltaTime * speed) * Mathf.Sin(Time.time * freq) * mag) * breakGame;
        _entity.transform.position += (_entity.transform.right * (FlyweightPointer.Entity.velocity + MovementManager.Instance.Multiplier) * Time.deltaTime) * breakGame;
    }

    public void Stop()
    {
        breakGame = 0;
    }
}
