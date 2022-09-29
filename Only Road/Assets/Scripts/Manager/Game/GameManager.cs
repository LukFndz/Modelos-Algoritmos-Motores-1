using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _avoidCars;

    [Header("MODIFIERS")]
    [SerializeField] private float _tileVelocityModifier;
    [SerializeField] private float _enemyVelocityModifier;
    [SerializeField] private int _scoreMultiplierModifier;

    [Header("MAX TILES VELOCITY")]
    [SerializeField] private float _maxTileVelocityModifier;

    [Header("CARS TO AVOID FOR MULTIPLIERS")]
    [SerializeField] private float _carsToAvoid;

    [Header("MANAGERS")]
    [SerializeField] private List<GameObject> _mainObjects;

    private bool _gameState;

    public bool GameState { get => _gameState; set => _gameState = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _avoidCars++;

            if (_avoidCars >= _carsToAvoid && TileManager.Instance.GetTilesVelocity() < _maxTileVelocityModifier) // MIENTRAS SEA MENOR A LA VELOCIDAD MAX DE LOS TILES, SE APLICAN LOS MULTIPLICADORES
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

    public void StartGame()
    {
        _gameState = true;
        foreach (GameObject g in _mainObjects) //DESACTIVA LOS OBJETOS QUE DEJAN DE SER NECESARIOS
            g.SetActive(true);
    }

    public void EndGame()
    {
        _gameState = false; // ESTADO DEL JUEGO A FALSO
        TileManager.Instance.ChangeTilesVelocity(-TileManager.Instance.GetTilesVelocity()); //FRENA LOS TILES
        foreach (GameObject g in _mainObjects) //DESACTIVA LOS OBJETOS QUE DEJAN DE SER NECESARIOS
            g.SetActive(false);

        ScoreManager.Instance.CheckHighscore(); //CHECKEA EL HIGHSCORE PARA CAMBIARLO SI LO SOBREPASO
        SavePlayerDataJSON.Instance.SaveParams(); //SALVA LO QUE CONSIGUIO EN LA PARTIDA.
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
