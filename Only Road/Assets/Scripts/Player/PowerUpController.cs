using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpController : PlayerComponent
{

    [SerializeField] private GameObject _tank;

    GameObject gTank;
    public override void ManualStart()
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
