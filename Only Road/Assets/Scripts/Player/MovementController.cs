using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementController : PlayerComponent
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _gameSpeed;

    private Vector3 _input;

    public float GameSpeed { get => _gameSpeed; set => _gameSpeed = value; }

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
            _rb.velocity += _player.transform.forward * _currentSpeed * _input.z;
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }
}
