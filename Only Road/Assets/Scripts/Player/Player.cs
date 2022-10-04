using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MovementController _movementController = new MovementController();

    [SerializeField] private PowerUpController _powerUpController = new PowerUpController();


    public delegate void ComponentMethod();
    public ComponentMethod _awake, _start, _update, _fixedUpdate, _onDrawGizmos;

    public MovementController MovementController { get => _movementController; set => _movementController = value; }
    public PowerUpController PowerUpController { get => _powerUpController; set => _powerUpController = value; }

    public Player()
    {
        _movementController.SetContext(this);
        PowerUpController.SetContext(this);
    }

    private void Awake() => _awake();

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        _start();
    }

    private void Update() => _update();
    private void FixedUpdate() => _fixedUpdate();
    private void OnDrawGizmos() => _onDrawGizmos();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) // SI TOCA UN ENEMIGO, ACTIVA EL ENDGAME
        {
            GameManager.Instance.GameOver();
            _movementController.ChangeSpeed(0); // CAMBIAR AL VELOCIDAD A 0
        }
    }

}
