using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementController : PlayerComponent
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;

    private Vector3 _input;

    public override void ManualUpdate()
    {
        GetInput();
    }

    public override void ManualFixedUpdate()
    {
        Move();
    }

    public void GetInput()
    {
        _input = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
    }

    public void Move()
    {
        if (_input != Vector3.zero)
        {
            _rb.velocity += _player.transform.forward * _speed * _input.z;
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
