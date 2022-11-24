using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpController
{
    [Header("TANK")]
    [SerializeField] private GameObject _tank;
    GameObject gTank;

    [Header("General")]
    private Player _player;
    private IPowerUp _actualPowerUp;
    private IInvencible _actualInvencible;

    public IPowerUp ActualPowerUp { get => _actualPowerUp; set => _actualPowerUp = value; }
    public IInvencible ActualInvencible { get => _actualInvencible; set => _actualInvencible = value; }

    public PowerUpController(Player player)
    {
        _player = player;
    }

    public void ManualStart()
    {
        gTank = GameObject.Instantiate(_tank);
        gTank.transform.position = _player.transform.position;
        gTank.transform.parent = _player.transform;
        gTank.SetActive(false);
    }

    public void Tank()
    {
        gTank.GetComponent<Tank>().StartTank();
    }

    public void SetInvencible(IInvencible set)
    {
        _actualInvencible = set;
    }

    public void DisableInvencible()
    {
        _actualInvencible = null;
    }

}
