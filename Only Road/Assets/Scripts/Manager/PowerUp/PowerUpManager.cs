using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpManager : Singleton<PowerUpManager>
{
    [SerializeField] private Player _player;

    [SerializeField] private float _tankTime;

    float timer;
    public float TankTime { get => _tankTime; set => _tankTime = value; }

    public void ActivatePowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.TANK:
                _player.PowerUpController.Tank();
                break;
        }
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "PowerUp");
    }
}