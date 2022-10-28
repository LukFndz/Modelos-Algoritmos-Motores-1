using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpManager : Singleton<PowerUpManager>
{
    [SerializeField] private Player _player;

    [SerializeField] private float _powerUpTime;

    float timer;
    public float PowerUpTime { get => _powerUpTime; set => _powerUpTime = value; }

    public void ActivatePowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.TANK:
                _player.MyModel.PowerUpController.Tank();
                break;
        }
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "PowerUp");
        UIManager.Instance.StartPowerUpTimer();
    }
}