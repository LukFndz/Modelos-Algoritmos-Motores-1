using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _avoidCars;
    [SerializeField]private float _tileVelocityModifier;
    [SerializeField]private float _enemyVelocityModifier;
    [SerializeField] private int _scoreMultiplierModifier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _avoidCars++;

            if (_avoidCars >= 1)
                ApplyMultipliers();
        }
    }

    public void ApplyMultipliers()
    {
        _avoidCars = 0;
        TileManager.Instance.ChangeTilesVelocity(_tileVelocityModifier);
        MovementManager.Instance.ChangeVelocity(_enemyVelocityModifier);
        ScoreManager.Instance.ChangeMultiplier(_scoreMultiplierModifier);
    }
}
