using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PowerUpManager : Singleton<PowerUpManager>
{
    [SerializeField] private Player _player;

    [SerializeField] private float _powerUpTime;

    [Header("TANK")]
    [SerializeField] private int _coinsPerHit;

    private IPowerUp _actualPowerUp;

    float timer;

    public float PowerUpTime { get => _powerUpTime; set => _powerUpTime = value; }
    public int CoinsPerHit { get => _coinsPerHit; set => _coinsPerHit = value; }
    public Player Player { get => _player; set => _player = value; }
    public IPowerUp ActualPowerUp { get => _actualPowerUp; set => _actualPowerUp = value; }

    public void ActivatePowerUp()
    {
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "PowerUp");
        UIManager.Instance.StartPowerUpTimer();
    }

    public void FinishPower()
    {
        _actualPowerUp.Disable();
        _actualPowerUp = null;
    }
}