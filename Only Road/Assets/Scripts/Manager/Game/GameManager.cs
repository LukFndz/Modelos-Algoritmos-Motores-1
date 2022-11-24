using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : Singleton<GameManager>
{

    public static bool restartGame = false;
    
    private int _avoidCars;

    [Header("PLAYER")]
    [SerializeField] private Player _player;

    [Header("MODIFIERS")]
    [SerializeField] private float _tileVelocityModifier;
    [SerializeField] private float _enemyVelocityModifier;
    [SerializeField] private int _scoreMultiplierModifier;
    [Range(0,10)]
    [SerializeField] private float _velPlayerMultiplierModifier;

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
        if (other.gameObject.GetComponent<IEnemy>() != null)
        {
            _avoidCars++;

            if (_avoidCars >= _carsToAvoid && TileManager.Instance.GetTilesVelocity() < _maxTileVelocityModifier) // MIENTRAS SEA MENOR A LA VELOCIDAD MAX DE LOS TILES, SE APLICAN LOS MULTIPLICADORES
            {
                EventManager.Instance.Trigger(EventManager.NameEvent.ApplyMultipliers,
                                    _tileVelocityModifier, _enemyVelocityModifier, _scoreMultiplierModifier);
                _avoidCars = 0;

                _player.MyModel.MovementController.UpdateSpeed(_velPlayerMultiplierModifier / 100);
            }
        }
    }

    public void StartGame()
    {
        if (StaminaManager.Instance.UseEnergy(StaminaManager.Instance.PlayEnergy))
        {
            _gameState = true;

            foreach (GameObject g in _mainObjects) //ACTIVA LOS OBJETOS QUE SON NECESARIOS
                g.SetActive(true);

            var player = FindObjectOfType<Player>();

            UIManager.Instance.SwitchCanvas(PanelType.IN_GAME_MENU);

            EventManager.Instance.Trigger(EventManager.NameEvent.StartGame, player.MyModel.MovementController.StartSpeed);
        }
    }

    public void GameOver()
    {
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "Explosion");

        EventManager.Instance.Trigger(EventManager.NameEvent.Gameover, 0f);

        EventManager.Instance.Trigger(EventManager.NameEvent.ApplyMultipliers,
            0f, 0f, 0f);

        _gameState = false; // ESTADO DEL JUEGO A FALSO

        foreach (GameObject g in _mainObjects) //DESACTIVA LOS OBJETOS QUE DEJAN DE SER NECESARIOS
            g.SetActive(false);

        UIManager.Instance.SwitchCanvas(PanelType.REWARD_MENU); //MENU DE DERROTA
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
        restartGame = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        restartGame = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckRestart()
    {
        if (restartGame)
            StartGame();
    }
}
