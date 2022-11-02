using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{

    [SerializeField] private PlayerModel _myModel;
    [SerializeField] private PlayerController _myController = new PlayerController();
    [SerializeField] private PlayerView _myView = new PlayerView();

    public delegate void Component();
    public Component _awake, _start, _update, _fixedUpdate, _onDrawGizmos;

    public PlayerModel MyModel { get => _myModel; set => _myModel = value; }
    public PlayerController MyController { get => _myController; set => _myController = value; }
    public PlayerView MyView { get => _myView; set => _myView = value; }

    public event Action OnDeath;

    public Player()
    {
        _myModel = new PlayerModel(this);
        _myModel.SetContext(this);
        _myController.SetContext(this);
        _myView.SetContext(this);
        OnDeath = delegate { };
    }

    private void Awake()
    {
        _awake();

        OnDeath += CancelController;
    }

    private void Start() => _start();


    private void Update() => _update();

    private void FixedUpdate() => _fixedUpdate();

    public void CancelController()
    {
        _myController = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var col = collision.gameObject?.GetComponent<IEnemy>();
        if (col != null && !_myModel.PowerUpController.IsInvencible) // SI TOCA UN ENEMIGO, ACTIVA EL ENDGAME
        {
            OnDeath();
            col.Touch();
        }
    }

}
