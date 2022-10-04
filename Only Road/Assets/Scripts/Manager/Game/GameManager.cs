using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

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

    private List<Entity> entities = new List<Entity>();

    private bool _gameState;

    public bool GameState { get => _gameState; set => _gameState = value; }
    public List<Entity> Entities { get => entities; set => entities = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _avoidCars++;

            if (_avoidCars >= _carsToAvoid && TileManager.Instance.GetTilesVelocity() < _maxTileVelocityModifier) // MIENTRAS SEA MENOR A LA VELOCIDAD MAX DE LOS TILES, SE APLICAN LOS MULTIPLICADORES
            {
                EventManager.Instance.Trigger(EventManager.NameEvent.ApplyMultipliers,
                                    _tileVelocityModifier, _enemyVelocityModifier, _scoreMultiplierModifier);
                _avoidCars = 0;
            }
        }
    }

    //public void ApplyMultipliers()
    //{
    //    _avoidCars = 0;
    //    TileManager.Instance.ChangeTilesVelocity(_tileVelocityModifier);
    //    MovementManager.Instance.ChangeVelocity(_enemyVelocityModifier);
    //    ScoreManager.Instance.ChangeMultiplier(_scoreMultiplierModifier);
    //}


    public void StartGame()
    {
        _gameState = true;

        foreach (GameObject g in _mainObjects) //DESACTIVA LOS OBJETOS QUE DEJAN DE SER NECESARIOS
            g.SetActive(true);

        var player = FindObjectOfType<Player>();
      
        EventManager.Instance.Trigger(EventManager.NameEvent.StartGame, player.MovementController.GameSpeed);
    }

    public void GameOver()
    {
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "Explosion");

        EventManager.Instance.Trigger(EventManager.NameEvent.Gameover, 0f);

        EventManager.Instance.Trigger(EventManager.NameEvent.ApplyMultipliers,
            -TileManager.Instance.GetTilesVelocity(), 0f, 0f);

        Entities.Where(x => x.gameObject.activeSelf == true).ToList().ForEach(x => x.EntityMovement.ChangeVelocity(0));

        _gameState = false; // ESTADO DEL JUEGO A FALSO

        foreach (GameObject g in _mainObjects) //DESACTIVA LOS OBJETOS QUE DEJAN DE SER NECESARIOS
            g.SetActive(false);

        UIManager.Instance.SwitchCanvas(PanelType.END_MENU); //MENU DE DERROTA

        //SpawnManager.Instance.DisableSpawners(); //DESHABILITA LOS SPAWNERS

        //AudioManager.Instance.ChangeEffect("Explosion"); //CAMBIA EL SONIDO EXPLOSION
        //AudioManager.Instance.PlayOneShot(); //REPRODUCE SONIDO

        //TileManager.Instance.ChangeTilesVelocity(-TileManager.Instance.GetTilesVelocity()); //FRENA LOS TILES

        //ScoreManager.Instance.CheckHighscore(); //CHECKEA EL HIGHSCORE PARA CAMBIARLO SI LO SOBREPASO
        //SavePlayerDataJSON.Instance.SaveParams(); //SALVA LO QUE CONSIGUIO EN LA PARTIDA.

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
