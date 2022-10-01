using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : Singleton<PowerUpManager>
{
    [SerializeField] private Player _player;

    [SerializeField] private float _tankTime;

    public float TankTime { get => _tankTime; set => _tankTime = value; }

    public void ActivatePowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.TANK:
                _player.PowerUpController.Tank();
                break;
        }
    }
}