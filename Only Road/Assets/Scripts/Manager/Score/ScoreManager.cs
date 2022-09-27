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
        CheckHighscore();
        UIManager.Instance.SetHighScore();
    }

    private void Update()
    {
        _score += Time.deltaTime * _metersMultiplier;
        UIManager.Instance.ChangeScore(_score);
    }

    public void CheckHighscore()
    {
        _highscore = SavePlayerDataJSON.Instance.Savedata.highscore;
        if (_score > _highscore)
        {
            _highscore = _score;
            UIManager.Instance.SetHighScore();
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

    public void ChangeMultiplier(int newMultiplier)
    {
        _metersMultiplier += newMultiplier;
    }
}
