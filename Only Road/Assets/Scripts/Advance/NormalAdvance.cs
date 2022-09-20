using UnityEngine;

public class NormalAdvance : IAdvance
{
    private float _velocity;
    private Rigidbody _rb;
    private GameObject _enemy;

    public NormalAdvance(float velocity, Rigidbody rb, GameObject enemy)
    {
        _velocity = velocity;
        _rb = rb;
        _enemy = enemy;
    }

    public void Advance()
    {
        _rb.velocity += _enemy.transform.right * _velocity;
    }
}
