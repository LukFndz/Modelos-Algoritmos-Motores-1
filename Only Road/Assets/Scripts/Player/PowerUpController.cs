using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpController
{
    [SerializeField] private GameObject _tank;
    private bool _isInvencible;

    private Player _player;

    GameObject gTank;

    public bool IsInvencible { get => _isInvencible; set => _isInvencible = value; }

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
}
