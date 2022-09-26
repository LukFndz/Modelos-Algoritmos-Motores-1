using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MovementController _movementController = new MovementController();


    public delegate void ComponentMethod();
    public ComponentMethod _awake, _start, _update, _fixedUpdate, _onDrawGizmos;

    public Player()
    {
        _movementController.SetContext(this);
    }

    private void Awake() => _awake();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _start();
    }

    private void Update() => _update();
    private void FixedUpdate() => _fixedUpdate();
    private void OnDrawGizmos() => _onDrawGizmos();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // SI TOCA UN ENEMIGO, ACTIVA EL ENDGAME
        {
            GameManager.Instance.EndGame();
            _movementController.ChangeSpeed(0); // CAMBIAR AL VELOCIDAD A 0
            var enemy = collision.gameObject.GetComponent<Entity>();
            enemy.EntityMovement.ChangeVelocity(0); // CAMBIAR AL VELOCIDAD A 0 DEL ENEMIGO
        }
    }

}
