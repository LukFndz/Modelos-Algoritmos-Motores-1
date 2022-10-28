using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementController
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _gameSpeed;

    private Player _player;

    private Vector3 _input;

    public float GameSpeed { get => _gameSpeed; set => _gameSpeed = value; }
    public Vector3 Input { get => _input; set => _input = value; }

    public MovementController(Player player)
    {
        _player = player;
    }

    public void ManualStart()
    {
        EventManager.Instance.Subscribe(EventManager.NameEvent.StartGame, ChangeSpeed);
        EventManager.Instance.Subscribe(EventManager.NameEvent.Gameover, ChangeSpeed);
    }

    public void ManualFixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _rb.velocity += _player.transform.forward * _currentSpeed * _input.z;
    }

    public void ChangeSpeed(params object[] parameters)
    {
        _currentSpeed = (float)parameters[0];
    }
}
