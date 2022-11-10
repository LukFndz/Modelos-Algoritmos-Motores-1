using UnityEngine;

public class NormalAdvance : IAdvance
{
    protected float _velocity;
    private Rigidbody _rb;
    private GameObject _entity;

    public NormalAdvance(Rigidbody rb, GameObject entity)
    {
        _velocity = FlyweightPointer.Entity.velocity;
        _rb = rb;
        _entity = entity;
    }

    ////TILES CONSTRUCTOR
    //public NormalAdvance(float velocity, Rigidbody rb, GameObject entity)
    //{
    //    _velocity = velocity;
    //    _rb = rb;
    //    _entity = entity;
    //}

    public void Advance() //AVANZA LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE
    {
        _entity.transform.position += _entity.transform.right * _velocity * Time.deltaTime;
    }

    public void ChangeVel(float newVel) //CAMBIA LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE
    {
        _velocity = newVel;
    }

    public float GetVelocity() //DEVUELVE LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE
    {
        return _velocity;
    }
}
