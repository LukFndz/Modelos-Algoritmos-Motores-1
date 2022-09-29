using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private float _metersMultiplier;

    private float _highscore;
    private float _score;

    private void Start()
    {
        SetHighScoreFromSave();
        CheckHighscore();

        UIManager.Instance.SetHighScore(); //SETEA EL HIGHSCORE QUE TIENE GUARDADO JSON EN EL UI

        if (!GameManager.Instance.GameState)
            gameObject.SetActive(false);
    }

    private void Update()
    {
        _score += Time.deltaTime * _metersMultiplier;
        UIManager.Instance.ChangeScore(_score);
    }

    public void SetHighScoreFromSave() //SETEA EL HIGHSCORE QUE TIENE GUARDADO JSON
    {
        _highscore = SavePlayerDataJSON.Instance.Savedata.highscore;
    }

    public void CheckHighscore() 
    {
        SetHighScoreFromSave();
        if (_score > _highscore)
        {
            _highscore = _score;
        }
    }

    public float GetScore()
    {
        return _score;
    }

    public float GetHighscore()
    {
        return _highscore;
    }

    public void ChangeMultiplier(int newMultiplier) //CAMBIA EL MULTIPLICADOR DE PUNTOS
    {
        _metersMultiplier += newMultiplier;
    }
}
