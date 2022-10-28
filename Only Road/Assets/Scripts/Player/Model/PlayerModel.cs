using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModel : PlayerComponent
{
    [SerializeField] private MovementController _movementController;

    [SerializeField] private PowerUpController _powerUpController;

    public PlayerModel(Player player)
    {
        _movementController = new MovementController(player);
        _powerUpController = new PowerUpController(player);
    }

    public override void ManualStart()
    {
        _movementController.ManualStart();
        _powerUpController.ManualStart();
    }

    public override void ManualFixedUpdate()
    {
        _movementController.ManualFixedUpdate();
    }

    public MovementController MovementController { get => _movementController; set => _movementController = value; }
    public PowerUpController PowerUpController { get => _powerUpController; set => _powerUpController = value; }
}
