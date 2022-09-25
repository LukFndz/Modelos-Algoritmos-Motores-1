using UnityEngine;

public class NormalAdvance : IAdvance
{
    private float _velocity;
    private Rigidbody _rb;
    private GameObject _entity;

    public NormalAdvance(float velocity, Rigidbody rb, GameObject entity)
    {
        _velocity = velocity;
        _rb = rb;
        _entity = entity;
    }

    public void Advance()
    {
        _entity.transform.position += _entity.transform.right * _velocity;
    }
}
